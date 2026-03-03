using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Services
{
    internal class AffinityHelper
    {
        public static bool IsCoreEnabled(IntPtr mask, int coreIndex)
        {
            long maskValue = mask.ToInt64();
            return (maskValue & (1L << coreIndex)) != 0;
        }

        public static IntPtr SetCoreMask(bool[] cores)
        {
            long mask = 0;

            for (int i = 0; i < cores.Length; i++)
            {
                if (cores[i])
                    mask |= (1L << i);
            }

            return new IntPtr(mask);
        }

    }
}
