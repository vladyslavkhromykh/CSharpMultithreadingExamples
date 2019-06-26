using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace CSharpMultithreading
{
    internal class Program
    {
        public static void TraceThreadAndTask(string info)
        {
            string taskInfo = Task.CurrentId == null ? "no task" : "task " +
            Task.CurrentId;
            Console.WriteLine($"{info} in thread {Thread.CurrentThread.ManagedThreadId}" +
            $"and {taskInfo}");
        }
    }
}