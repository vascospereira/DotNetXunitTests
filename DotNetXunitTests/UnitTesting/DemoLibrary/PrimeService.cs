using System;

namespace DemoLibrary
{
    public static class PrimeService
    {
        public static bool IsPrime(int value)
        {
            if (value < 2)
            {
                return false;
            }

            for (var i = 2; i <= Math.Sqrt(value); i++)
            {
                if (value % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
