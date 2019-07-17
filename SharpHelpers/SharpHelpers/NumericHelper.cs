namespace SharpCoding.SharpHelpers
{
    public static class NumericHelper
    {
        public static bool IsOdd(this int numberToCheck)
        {
            var restOfDivision = (numberToCheck % 2);
            return (restOfDivision == 1);
        }

        public static bool IsEven(this int numberToCheck)
        {
            return !numberToCheck.IsOdd();
        }
    }
}
