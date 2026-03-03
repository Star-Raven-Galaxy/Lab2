using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
namespace Lab2.Services
{
    internal class ProcessTreeService
    {
        public int GetParentProcessId(int processId)
        {
            using (var query = new ManagementObjectSearcher(
                "SELECT ParentProcessId FROM Win32_Process WHERE ProcessId = " + processId))
            {
                var result = query.Get()
                    .Cast<ManagementObject>()
                    .FirstOrDefault();

                if (result != null)
                    return (int)(uint)result["ParentProcessId"];

                return 0;
            }
        }

        public List<ProcessTreeNode> BuildTree(List<ProcessInfo> processes)
        {
            var dict = processes.ToDictionary(
                p => p.Id,
                p => new ProcessTreeNode { Process = p });

            var roots = new List<ProcessTreeNode>();

            foreach (var node in dict.Values)
            {
                int parentId = GetParentProcessId(node.Process.Id);

                if (dict.ContainsKey(parentId))
                    dict[parentId].Children.Add(node);
                else
                    roots.Add(node);
            }

            return roots;
        }
    }
}
