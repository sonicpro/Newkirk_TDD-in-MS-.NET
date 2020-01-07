using System;
using System.Collections;

namespace Chapter3
{
    public class Primes
    {
        public static ArrayList Generate(int maxValue)
        {
            var result = new ArrayList();
            result.AddRange(GenerateArray(maxValue));
            return result;
        }

        [Obsolete("This method is obsolete, use Generate instead")]
        public static int[] GenerateArray(int maxValue)
        {
            if (maxValue >= 2)
            {
                // Let's array indices represent natural numbers list
                int s = maxValue + 1; // size of array
                var f = new bool[s];
                int i;

                // Let's assume initially that every number from 2 to maxValue is prime
                for (i = 0; i < s; i++)
                {
                    f[i] = true;
                }
                f[0] = f[1] = false;

                // Sieve
                int j;
                // "Strike out the multiples of all primes less than or equal to the square root of maxValue; the numbers that are left are the primes."
                for (i = 2; i < Math.Sqrt(s); i++)
                {
                    for (j = 2 * i; j < s; j += i)
                    {
                        f[j] = false; // Quite ineffective implementation, for maxValue >= 24 we strike out the multiples of non-primes like 4, which is redundant
                    }
                }

                // How many primes are from 2 to maxValue (inclusively)?
                int count = 0;
                for (i = 0; i < s; i++)
                {
                    if (f[i])
                    {
                        count++;
                    }
                }

                var result = new int[count];

                // Fill in the result array with values (which are "f" array indices).
                for (i = 0, j = 0; i < s; i++)
                {
                    if (f[i]) // means "i" is prime
                    {
                        result[j++] = i;
                    }
                }

                return result;
            } // maxValue >= 2
            else
            {
                return new int[0];
            }
        }
    }
}
