using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DCUtil.Test.Task.Promise
{
    using DCUtil.Task;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading;

    [TestClass]
    public class PromiseTests
    {
        private async Task RecursiveAwait(Task task, int recursionCount)
        {
            Debug.WriteLine($"Recursive: {recursionCount}");
            if (recursionCount-- == 0) return;
            await RecursiveAwait(task, recursionCount);
            
        }
        
        [TestMethod]
        public void RecursiveAwaitBaseLine()
        {
            var sw = new Stopwatch();
            sw.Start();
            var  task = RecursiveAwait(Task.FromResult(0), 10000);
            task.Wait();
            sw.Stop();
        }

        [TestMethod]
        public void RecursiveThenBaseLine()
        {
            var sw = new Stopwatch();
            sw.Start();
            var task =  RecursiveThen(Task.FromResult(0), 10000);
            task.Wait();
            sw.Stop();
        }

        private static Task Empty = Task.FromResult(0);

        private Task RecursiveThen(Task task, int recursionCount)
        {
            while(recursionCount-- > 0)
            {
                var temp = recursionCount;
                task = task.Then(() =>
                {
                    Debug.WriteLine($"Then: {temp}");
                }, CancellationToken.None);
            }

            return task;
        }
    }
}
