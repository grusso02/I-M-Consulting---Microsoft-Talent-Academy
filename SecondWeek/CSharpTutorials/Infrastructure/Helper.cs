using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class Helper
    {
        public static bool GetNumElements(int[] arr, ref int? elements)
        {
            arr = new int[] { 200, 2, 3 };
            //elements = 0;
            bool retval = arr != null;
            if (retval)
                elements = arr.Length;
            return retval;
        }
    }
}
