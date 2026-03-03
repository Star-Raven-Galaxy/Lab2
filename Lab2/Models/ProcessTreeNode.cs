using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Models
{
    internal class ProcessTreeNode
    {
        public ProcessInfo Process { get; set; }
        public List<ProcessTreeNode> Children { get; set; }

        public ProcessTreeNode()
        {
            Children = new List<ProcessTreeNode>();
        }
    }
}
