using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Threading;
using Task3.Model;

namespace Task3
{
    public static class Program
    {
        private static ConcurrentQueue<(string, string)> queue;
        private static CountdownEvent countdown;

        public static void Main()
        {
            var successful = 0;
            var failed = 0;
            Console.WriteLine("Task_3.Unique login service.");
            Console.WriteLine("Author: Halych Ivan");
            Console.WriteLine("Enter count thread:");
            _ = int.TryParse(Console.ReadLine(), out var countThread);
            try
            {
                queue = new ConcurrentQueue<(string, string)>(WorkWithFile.Read());
                var count = queue.Count;
                countdown = new CountdownEvent(count);
                Enumerable.Range(0, countThread).AsParallel().ForAll(thread => new Thread(() =>
                {
                    while (queue.TryDequeue(out var item))
                    {
                        if (LoginClien.Login(item.Item1, item.Item2) != null)
                        {
                            Interlocked.Increment(ref successful);
                        }
                        else
                        {
                            Interlocked.Increment(ref failed);
                        }

                        countdown.Signal();
                    }
                }).Start());
                countdown.Wait();
                if (count == successful + failed)
                {
                    Console.WriteLine($"Successful:{successful}");
                    Console.WriteLine($"Failed:{failed}");
                    WorkWithFile.Write(new Result(successful, failed));
                }
                else
                {
                    Console.WriteLine(
                        "Error:the number of login / password pairs in the source file is different with the number of login attempts");
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
