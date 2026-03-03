using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace Lab2.Models
{
    internal class ProcessInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProcessPriorityClass Priority { get; set; }
        public long MemoryUsage { get; set; }
        public int ThreadCount { get; set; }
        public TimeSpan CpuTime { get; set; }

        public bool HasWindow { get; set; }
        public bool IsSystemProcess { get; set; }
    }
}
