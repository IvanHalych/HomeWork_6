using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using Task1;
using Task2.Model;

namespace Task2
{
    public static class Program
    {
        private static readonly ThreadSafeList SafeList = new ThreadSafeList();

        public static void Main()
        {
            var stopwatch = new Stopwatch();
            try
            {
                var setting = FileWork.Read();
                setting = setting.Where(s => s != null).ToList();
                stopwatch.Restart();
                var threadsList = new List<Thread>();
                setting.ForEach(s =>
                {
                    var t = new Thread(SearchPrimesNumber);
                    t.Start(s);
                    threadsList.Add(t);
                });
                threadsList.ForEach(t => t.Join());

                stopwatch.Stop();
                FileWork.Write(new Result(stopwatch.Elapsed.ToString(), true, SafeList.GetAll().OrderBy(i => i).ToList(), null));
            }
            catch (FileNotFoundException ex)
            {
                stopwatch.Stop();
                FileWork.Write(new Result(stopwatch.Elapsed.ToString(), false, null, ex.Message));
            }
            catch (JsonException ex)
            {
                stopwatch.Stop();
                FileWork.Write(new Result(stopwatch.Elapsed.ToString(), false, null, ex.Message));
            }
        }

        private static void SearchPrimesNumber(object obj)
        {
            var setting = (Setting)obj;
            if (setting.PrimesFrom < setting.PrimesTo)
            {
                var list = new List<int>();
                list = Enumerable.Range(setting.PrimesFrom, setting.PrimesTo - setting.PrimesFrom).ToList();
                list.AsParallel().ForAll(i =>
                {
                    if (i.IsPrimeNumber())
                    {
                        SafeList.Add(i);
                    }
                });
            }
        }
    }
}
