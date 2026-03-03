using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using Lab2.Models;
namespace Lab2.Services
{
    internal class ThreadService
    {
        public List<ThreadInfo> GetThreads(int processId)
        {
            var result = new List<ThreadInfo>();

            try
            {
                var process = Process.GetProcessById(processId);

                foreach (ProcessThread thread in process.Threads)
                {
                    result.Add(new ThreadInfo
                    {
                        Id = thread.Id,
                        Priority = thread.PriorityLevel,
                        State = thread.ThreadState,
                        CpuTime = thread.TotalProcessorTime
                    });
                }
            }
            catch (Win32Exception ex)
            {
                throw new System.Exception("Недостаточно прав: " + ex.Message);
            }
            catch (InvalidOperationException)
            {
                throw new System.Exception("Процесс завершился.");
            }
            catch (ArgumentException)
            {
                throw new System.Exception("Процесс не найден.");
            }

            return result;
        }
    }
}
