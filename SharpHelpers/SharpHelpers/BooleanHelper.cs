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
    public static class BooleanHelper
    {
        /// <summary>
        /// This method returns TRUE when istance is different from op2
        /// </summary>
        /// <param name="istance"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
        public static bool Xor(this bool istance, bool op2)
        {
            return istance ^ op2;
        }

        /// <summary>
        /// This method returns TRUE when both istance and op2 are true
        /// </summary>
        /// <param name="istance"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
        public static bool And(this bool istance, bool op2)
        {
            return istance && op2;
        }

        /// <summary>
        /// This method returns TRUE when istance that invokes the method or parameter is true.
        /// It returns true when also both are true
        /// </summary>
        /// <param name="istance"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
        public static bool Or(this bool istance, bool op2)
        {
            return istance || op2;
        }

        /// <summary>
        /// This method maps the instance value in one of the two parameters
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToStringValues(this bool? value, string trueValue, string falseValue)
        {
            return value.HasValue ? (value.Value ? trueValue : falseValue) : falseValue;
        }
    }
}
