using System;

namespace Task1
{
    public static class PrimeNumber
    {
        public static bool IsPrimeNumber(this int n)
        {
            var result = true;

            if (n > 1)
            {
                for (var i = 2u; i <= (int)Math.Sqrt(n); i++)
                {
                    if (n % i == 0)
                    {
                        result = false;
                        break;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }
    }
}
