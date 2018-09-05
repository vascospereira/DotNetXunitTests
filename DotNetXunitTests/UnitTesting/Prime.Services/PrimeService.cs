using System;

namespace Prime.Services
{
    public class PrimeService
    {
        public bool IsPrime(int value)
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
