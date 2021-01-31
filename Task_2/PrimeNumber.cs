using System;

namespace Task1
{
    public static class PrimeNumber
    {
        public static bool IsPrimeNumber(this int n)
        {
            if (n <= 1)
            {
                return false;
            }

            for (var i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
