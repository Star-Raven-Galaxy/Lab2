
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2.Services;
using Lab2.Models;
using System.Diagnostics;
namespace ProcessManager.Tests
{
    [TestClass]
    public class ProcessOperationServiceTests
    {
        private ProcessOperationService service;

        [TestInitialize]
        public void Setup()
        {
            service = new ProcessOperationService();
        }

        // SEARCH

        [TestMethod]
        public void Search_ReturnsMatchingProcesses()
        {
            var list = new List<ProcessInfo>
        {
            new ProcessInfo { Name="chrome"},
            new ProcessInfo { Name="explorer"},
            new ProcessInfo { Name="chrome_helper"}
        };

            var result = service.Search(list, "chrome");

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void Search_ReturnsEmpty_WhenNoMatch()
        {
            var list = new List<ProcessInfo>
        {
            new ProcessInfo { Name="notepad"},
            new ProcessInfo { Name="explorer"}
        };

            var result = service.Search(list, "chrome");

            Assert.AreEqual(0, result.Count);
        }

        // FILTER GUI

        [TestMethod]
        public void FilterGUI_ReturnsOnlyWindowProcesses()
        {
            var list = new List<ProcessInfo>
        {
            new ProcessInfo { HasWindow=true },
            new ProcessInfo { HasWindow=false },
            new ProcessInfo { HasWindow=true }
        };

            var result = service.FilterGUI(list);

            Assert.AreEqual(2, result.Count);
        }

        // FILTER SYSTEM

        [TestMethod]
        public void FilterSystem_ReturnsOnlySystemProcesses()
        {
            var list = new List<ProcessInfo>
        {
            new ProcessInfo { IsSystemProcess=true },
            new ProcessInfo { IsSystemProcess=false },
            new ProcessInfo { IsSystemProcess=true }
        };

            var result = service.FilterSystem(list);

            Assert.AreEqual(2, result.Count);
        }

       

        // SORT MEMORY

        [TestMethod]
        public void Sort_ByMemory_ReturnsSorted()
        {
            var list = new List<ProcessInfo>
        {
            new ProcessInfo { Name="a", MemoryUsage=100 },
            new ProcessInfo { Name="b", MemoryUsage=500 },
            new ProcessInfo { Name="c", MemoryUsage=200 }
        };

            var result = service.Sort(list, "Memory");

            Assert.AreEqual("b", result[0].Name);
        }

        // SORT THREADS

        [TestMethod]
        public void Sort_ByThreads_ReturnsSorted()
        {
            var list = new List<ProcessInfo>
        {
            new ProcessInfo { Name="a", ThreadCount=3 },
            new ProcessInfo { Name="b", ThreadCount=10 },
            new ProcessInfo { Name="c", ThreadCount=5 }
        };

            var result = service.Sort(list, "Threads");

            Assert.AreEqual("b", result[0].Name);
        }

        // SORT DEFAULT

        [TestMethod]
        public void Sort_Default_ReturnsSortedByName()
        {
            var list = new List<ProcessInfo>
        {
            new ProcessInfo { Name="z" },
            new ProcessInfo { Name="a" },
            new ProcessInfo { Name="m" }
        };

            var result = service.Sort(list, "Other");

            Assert.AreEqual("a", result[0].Name);
        }

        // KILL PROCESS

        [TestMethod]
        public void KillProcess_ShouldTerminateProcess()
        {
            var process = Process.Start("notepad.exe");

            service.KillProcess(process.Id);

            process.WaitForExit();

            Assert.IsTrue(process.HasExited);
        }
    }
}