namespace DCUtil.Task
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static partial class TaskExtensions
    {
        public static Task Catch(this Task task, Action<Exception> onException)
        {
            var tcs = new TaskCompletionSource<VoidResult>();
            task.ContinueWith(t =>
            {
                try
                {
                    switch (t.Status)
                    {
                        case TaskStatus.RanToCompletion:
                            tcs.SetResult(voidResult);
                            break;
                        case TaskStatus.Faulted:
                            onException(t.Exception);
                            tcs.SetResult(voidResult);
                            break;
                        case TaskStatus.Canceled:
                            onException(new TaskCanceledException(t));
                            tcs.SetResult(voidResult);
                            break;
                    }
                }
                catch (Exception e)
                {
                    tcs.SetException(e);
                }
            });

            return tcs.Task;
        }

    }
}
