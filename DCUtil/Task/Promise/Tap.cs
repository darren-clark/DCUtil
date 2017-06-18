namespace DCUtil.Task
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    public partial class TaskExtensions
    {
        private static partial class Continuations<T>
        {
            public static Action<T, Action<T>, TaskCompletionSource<T>> TapAction = (r, action, tcs) =>
            {
                action(r);
                tcs.SetResult(r);
            };

            public static Action<T, Func<T, Task>, TaskCompletionSource<T>> TapTask = (r, action, tcs) => 
                action(r).OnSuccess(r, TapComplete, CancellationToken.None);

            public static Action<T, TaskCompletionSource<T>> TapComplete = (r, tcs) => tcs.SetResult(r);

            public static class DummyReturn<TDummy>
            {
                public static Action<T, Func<T, TDummy>, TaskCompletionSource<T>> TapAction = (r, action, tcs) =>
                 {
                     action(r);
                     tcs.SetResult(r);
                 };

                public static Action<T, Func<T, Task<TDummy>>, TaskCompletionSource<T>> TapTask = (r, action, tcs) =>
                    action(r).OnSuccess(r, TapComplete, CancellationToken.None);
            }
        }

        public static Task<T> Tap<T>(this Task<T> task, Action<T> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess(action, Continuations<T>.TapAction, cancellationToken);
        }

        public static Task<T> Tap<T>(this Task<T> task, Func<T, Task> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess(action, Continuations<T>.TapTask, cancellationToken);
        }

        public static Task<T> Tap<T, TDummy>(this Task<T> task, Func<T,TDummy> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess(action, Continuations<T>.DummyReturn<TDummy>.TapAction, cancellationToken);
        }

        public static Task<T> Tap<T, TDummy>(this Task<T> task, Func<T, Task<TDummy>> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess(action, Continuations<T>.DummyReturn<TDummy>.TapTask, cancellationToken);
        }
    }
}
