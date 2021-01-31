using System;
using System.Diagnostics;
using System.Linq;

namespace Task1
{
    public static class SearchPrimeNumbers
    {
        private static readonly Stopwatch Stopwatch = new Stopwatch();

        public static void SearchPrimeNumbersWithLINQ(int from, int to)
        {
            var array = Enumerable.Range(from, to - from);
            Stopwatch.Restart();
            var count = array.Count(a => a.IsPrimeNumber());
            Stopwatch.Stop();
            Console.WriteLine($"LINQ: Count = {count}, Time = {Stopwatch.Elapsed}");
        }

        public static void SearchPrimeNumbersWithPLINQ(int from, int to)
        {
            var array = Enumerable.Range(from, to - from);
            Stopwatch.Restart();
            var count = array.AsParallel().Count(a => a.IsPrimeNumber());
            Stopwatch.Stop();
            Console.WriteLine($"PLINQ: Count = {count}, Time = {Stopwatch.Elapsed}");
        }
    }
 }
