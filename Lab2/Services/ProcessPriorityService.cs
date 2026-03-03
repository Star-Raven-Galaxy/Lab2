using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2.Services
{
    internal class ProcessPriorityService
    {
        public bool SetProcessPriority(int processId, ProcessPriorityClass priority)
        {
            try
            {
                if (priority == ProcessPriorityClass.RealTime)
                {
                    var result = MessageBox.Show(
                        "Приоритет Realtime может нарушить работу системы. Продолжить?",
                        "Внимание!",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                        return false;
                }

                var process = Process.GetProcessById(processId);
                process.PriorityClass = priority;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return false;
            }
        }

        public ProcessPriorityClass? GetCurrentPriority(int processId)
        {
            try
            {
                var process = Process.GetProcessById(processId);
                return process.PriorityClass;
            }
            catch
            {
                return null;
            }
        }
    }
}
