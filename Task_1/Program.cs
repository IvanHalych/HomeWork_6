using System;

namespace Task1
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Task_1.Search for prime numbers using LINQ and PLINQ.");
            Console.WriteLine("Author: Halych Ivan");
            int from;
            int to;
            while (true)
            {
                Console.Write("Enter range numbers(from:to(100:5555)):");
                var input = Console.ReadLine();
                var array = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                if (!int.TryParse(array[0], out from))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                if (!int.TryParse(array[1], out to))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                if (to < from)
                {
                    Console.WriteLine("Invalid because first number is larger then second number!");
                    continue;
                }

                break;
            }

            var flag = true;
            while (flag)
            {
                Console.WriteLine("Select how to search for prime numbers");
                Console.WriteLine("1. LINQ");
                Console.WriteLine("2. PLINQ");
                Console.WriteLine("3. Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        SearchPrimeNumbers.SearchPrimeNumbersWithLINQ(from, to);
                        break;
                    case "2":
                        SearchPrimeNumbers.SearchPrimeNumbersWithPLINQ(from, to);
                        break;
                    case "3":
                        flag = false;
                      break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }
}
