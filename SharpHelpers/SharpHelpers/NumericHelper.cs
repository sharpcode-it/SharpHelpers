// (c) 2019 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)
using System;

namespace SharpCoding.SharpHelpers
{
    public static class NumericHelper
    {
        /// <summary>
        /// Checks if the integer number is odd.
        /// </summary>
        /// <param name="numberToCheck">The integer number to check.</param>
        /// <returns>True if the number is odd; otherwise, false.</returns>
        public static bool IsOdd(this int numberToCheck)
        {
            var restOfDivision = (numberToCheck % 2);
            return (restOfDivision == 1);
        }

        /// <summary>
        /// Checks if the integer number is even.
        /// </summary>
        /// <param name="numberToCheck">The integer number to check.</param>
        /// <returns>True if the number is even; otherwise, false.</returns>
        public static bool IsEven(this int numberToCheck)
        {
            return !numberToCheck.IsOdd();
        }

        /// <summary>
        /// Checks if the integer number is prime.
        /// </summary>
        /// <param name="numberToCheck">The integer number to check.</param>
        /// <returns>True if the number is prime; otherwise, false.</returns>
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

        /// <summary>
        /// Calculates the factorial of the integer number.
        /// </summary>
        /// <param name="number">The integer number to calculate the factorial for.</param>
        /// <returns>The factorial of the number.</returns>
        /// <exception cref="ArgumentException">Thrown when the number is negative.</exception>
        public static long Factorial(this int number)
        {
            if (number < 0) throw new ArgumentException("Number must be non-negative.");
            return number <= 1 ? 1 : number * Factorial(number - 1);
        }

        /// <summary>
        /// Computes the Greatest Common Divisor (GCD) of two integers.
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The greatest common divisor of the two numbers.</returns>
        public static int GCD(this int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        /// <summary>
        /// Computes the Least Common Multiple (LCM) of two integers.
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The least common multiple of the two numbers.</returns>
        public static int LCM(this int a, int b)
        {
            return Math.Abs(a * b) / a.GCD(b);
        }

        /// <summary>
        /// Checks if the integer number is negative.
        /// </summary>
        /// <param name="number">The integer number to check.</param>
        /// <returns>True if the number is negative; otherwise, false.</returns>
        public static bool IsNegative(this int number)
        {
            return number < 0;
        }

        /// <summary>
        /// Checks if the integer number is positive.
        /// </summary>
        /// <param name="number">The integer number to check.</param>
        /// <returns>True if the number is positive; otherwise, false.</returns>
        public static bool IsPositive(this int number)
        {
            return number > 0;
        }

        /// <summary>
        /// Clamps the integer number within the specified range.
        /// </summary>
        /// <param name="value">The integer number to clamp.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The clamped value within the specified range.</returns>
        public static int Clamp(this int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        /// <summary>
        /// Returns the absolute value of the integer number.
        /// </summary>
        /// <param name="number">The integer number to get the absolute value for.</param>
        /// <returns>The absolute value of the number.</returns>
        public static int Abs(this int number)
        {
            return Math.Abs(number);
        }

        /// <summary>
        /// Checks if the integer is divisible by a specified divisor.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="divisor">The divisor.</param>
        /// <returns>True if divisible; otherwise, false.</returns>
        public static bool IsDivisibleBy(this int number, int divisor)
        {
            if (divisor == 0) throw new DivideByZeroException("Divisor cannot be zero.");
            return number % divisor == 0;
        }

        /// <summary>
        /// Calculates the percentage this number represents of a total.
        /// </summary>
        /// <param name="number">The partial value.</param>
        /// <param name="total">The total value.</param>
        /// <returns>The percentage as a double.</returns>
        public static double ToPercentageOf(this int number, int total)
        {
            if (total == 0) throw new DivideByZeroException("Total cannot be zero.");
            return (double)number / total * 100;
        }

        /// <summary>
        /// Checks whether the integer is within the specified inclusive range.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="min">The minimum bound.</param>
        /// <param name="max">The maximum bound.</param>
        /// <returns>True if within range; otherwise, false.</returns>
        public static bool IsInRange(this int number, int min, int max)
        {
            return number >= min && number <= max;
        }

        /// <summary>
        /// Returns the next multiple of the specified factor greater than or equal to the number.
        /// </summary>
        /// <param name="number">The base number.</param>
        /// <param name="factor">The factor.</param>
        /// <returns>The next multiple of the factor.</returns>
        public static int NextMultipleOf(this int number, int factor)
        {
            if (factor == 0) throw new ArgumentException("Factor cannot be zero.");
            int remainder = number % factor;
            return remainder == 0 ? number : number + (factor - remainder);
        }

        /// <summary>
        /// Checks whether the integer is a power of two.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <returns>True if the number is a power of two; otherwise, false.</returns>
        public static bool IsPowerOfTwo(this int number)
        {
            return number > 0 && (number & (number - 1)) == 0;
        }
    }
}
