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
    internal class ProcessOperationService
    {
        public void KillProcess(int processId)
        {
            try
            {
                Process.GetProcessById(processId).Kill();
            }
            catch (Win32Exception ex)
            {
                throw new Exception("Недостаточно прав: " + ex.Message);
            }
            catch (InvalidOperationException)
            {
                throw new Exception("Процесс уже завершён.");
            }
            catch (ArgumentException)
            {
                throw new Exception("Процесс не найден.");
            }
        }

        public List<ProcessInfo> Search(List<ProcessInfo> list, string name)
        {
            return list
                .Where(p => p.Name.ToLower().Contains(name.ToLower()))
                .ToList();
        }

        public List<ProcessInfo> FilterGUI(List<ProcessInfo> list)
        {
            return list.Where(p => p.HasWindow).ToList();
        }

        public List<ProcessInfo> FilterSystem(List<ProcessInfo> list)
        {
            return list.Where(p => p.IsSystemProcess).ToList();
        }

        public List<ProcessInfo> Sort(List<ProcessInfo> list, string field)
        {
            if (field == "CPU")
                return list.OrderByDescending(p => p.CpuTime).ToList();

            if (field == "Memory")
                return list.OrderByDescending(p => p.MemoryUsage).ToList();

            if (field == "Threads")
                return list.OrderByDescending(p => p.ThreadCount).ToList();

            return list.OrderBy(p => p.Name).ToList();
        }
    }
}
