using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCoding.SharpHelpers
{
    public static class BooleanHelper
    {
        public static bool Xor(this bool istance, bool op2)
        {
            return istance ^ op2;
        }

        public static bool And(this bool istance, bool op2)
        {
            return istance && op2;
        }
		
        public static bool Or(this bool istance, bool op2)
        {
            return istance || op2;
        }
    }
}
