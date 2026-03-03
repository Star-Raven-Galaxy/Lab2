using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Lab2.Models;
using System.ComponentModel;
namespace Lab2.Services
{
    internal class ProcessInfoService
    {
        public List<ProcessInfo> GetAllProcesses()
        {
            var list = new List<ProcessInfo>();

            foreach (var p in Process.GetProcesses())
            {
                try
                {
                    list.Add(new ProcessInfo
                    {
                        Id = p.Id,
                        Name = p.ProcessName,
                        Priority = p.PriorityClass,
                        MemoryUsage = p.WorkingSet64,
                        ThreadCount = p.Threads.Count,
                        CpuTime = p.TotalProcessorTime,
                        HasWindow = p.MainWindowHandle != IntPtr.Zero,
                        IsSystemProcess = p.SessionId == 0
                    });
                }
                catch (Win32Exception)
                {
                    // нет доступа
                }
                catch (InvalidOperationException)
                {
                    // процесс завершился
                }
            }

            return list;
        }
    }
}
