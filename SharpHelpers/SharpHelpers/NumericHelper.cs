using System;

namespace SharpCoding.SharpHelpers
{
    // (c) 2019 SharpCoding
    // This code is licensed under MIT license (see LICENSE.txt for details)
    public static class NumericHelper
    {
        /// <summary>
        /// check if the int number that invokes the method is odd
        /// </summary>
        /// <param name="numberToCheck"></param>
        /// <returns></returns>
        public static bool IsOdd(this int numberToCheck)
        {
            var restOfDivision = (numberToCheck % 2);
            return (restOfDivision == 1);
        }

        /// <summary>
        /// check if the int number that invokes the method is even
        /// </summary>
        /// <param name="numberToCheck"></param>
        /// <returns></returns>
        public static bool IsEven(this int numberToCheck)
        {
            return !numberToCheck.IsOdd();
        }

        /// <summary>
        /// check if the int number that invokes the method is prime
        /// </summary>
        /// <param name="numberToCheck"></param>
        /// <returns></returns>
        public static bool IsPrime(this int numberToCheck)
        {            
            var limit = Math.Ceiling(Math.Sqrt(numberToCheck));
            for (var i = 2; i <= limit; i++)
            {
                if (numberToCheck % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
