using System;

namespace SharpCoding.SharpHelpers
{
    /*
     * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
     * "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
     * LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
     * A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
     * OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
     * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
     * LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
     * DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
     * THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
     * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
     * OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
     *
     * This software consists of voluntary contributions made by many individuals
     * and is licensed under the MIT license. For more information, see
     * <http://www.doctrine-project.org>.
     */
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
