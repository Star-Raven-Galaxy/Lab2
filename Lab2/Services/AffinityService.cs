using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Services
{
    internal class AffinityService
    {

        public int GetCoreCount() => Environment.ProcessorCount;

        public IntPtr GetAffinity(int processId)
        {
            return Process.GetProcessById(processId).ProcessorAffinity;
        }

        public void SetAffinity(int processId, IntPtr mask)
        {
            try
            {
                var process = Process.GetProcessById(processId);
                process.ProcessorAffinity = mask;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка установки affinity: " + ex.Message);
            }
        }

        public string ToBinary(IntPtr mask)
        {
            return Convert.ToString(mask.ToInt64(), 2);
        }

        public string ToHex(IntPtr mask)
        {
            return "0x" + mask.ToInt64().ToString("X");
        }
    }
}
