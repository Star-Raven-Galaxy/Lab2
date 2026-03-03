using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab2.Models
{
    internal class ThreadInfo
    {
        public int Id { get; set; }
        public ThreadPriorityLevel Priority { get; set; }
        public ThreadState State { get; set; }
        public TimeSpan CpuTime { get; set; }
    }
}
