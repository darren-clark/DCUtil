namespace DCUtil.Task
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    public partial class TaskExtensions
    {
        private static partial class Continuations
        {
            public static partial class Result<TResult>
            {
                public static Action<TResult, Action<TResult>, TaskCompletionSource<TResult>> TapAction = (r, action, tcs) =>
                {
                    action(r);
                    tcs.SetResult(r);
                };

                public static Action<TResult, Func<TResult, Task>, TaskCompletionSource<TResult>> TapTask = (r, action, tcs) =>
                    action(r).OnSuccess(r, TapComplete, CancellationToken.None);

                public static Action<TResult, TaskCompletionSource<TResult>> TapComplete = (r, tcs) => tcs.SetResult(r);

                public static partial class Dummy<TDummy>
                {
                    public static Action<TResult, Func<TResult, TDummy>, TaskCompletionSource<TResult>> TapAction = (r, action, tcs) =>
                    {
                        action(r);
                        tcs.SetResult(r);
                    };

                    public static Action<TResult, Func<TResult, Task<TDummy>>, TaskCompletionSource<TResult>> TapTask = (r, action, tcs) =>
                        action(r).OnSuccess(r, TapComplete, CancellationToken.None);
                }
            }
        }

        public static Task<T> Tap<T>(this Task<T> task, Action<T> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess(action, Continuations.Result<T>.TapAction, cancellationToken);
        }

        public static Task<T> Tap<T>(this Task<T> task, Func<T, Task> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess(action, Continuations.Result<T>.TapTask, cancellationToken);
        }

        public static Task<T> Tap<T, TDummy>(this Task<T> task, Func<T,TDummy> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess(action, Continuations.Result<T>.Dummy<TDummy>.TapAction, cancellationToken);
        }

        public static Task<T> Tap<T, TDummy>(this Task<T> task, Func<T, Task<TDummy>> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess(action, Continuations.Result<T>.Dummy<TDummy>.TapTask, cancellationToken);
        }
    }
}
