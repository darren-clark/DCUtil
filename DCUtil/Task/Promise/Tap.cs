namespace DCUtil.Task
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    public partial class TaskExtensions
    {
        public static Task<T> Tap<T>(this Task<T> task, Action<T> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess<T, T, Action<T>>(action, (r,ctx, tcs) => { ctx(r); tcs.SetResult(r); }, cancellationToken);
        }

        public static Task<T> Tap<T>(this Task<T> task, Func<T, Task> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess<T, T, Func<T, Task>>(action, (r, ctx, tcs) => ctx(r).OnSuccess<T,T>(r, (rnext, next) => next.SetResult(rnext), CancellationToken.None), cancellationToken);
        }

        public static Task<T> Tap<T,TInner>(this Task<T> task, Func<T,TInner> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess<T, T, Func<T,TInner>>(action, (r,ctx, tcs) => { ctx(r); tcs.SetResult(r); }, cancellationToken);
        }

        public static Task<T> Tap<T, TInner>(this Task<T> task, Func<T, Task<TInner>> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess<T, T, Func<T, Task<TInner>>>(action, (r, ctx, tcs) => ctx(r).OnSuccess<T,T>(r, (rnext, next) => next.SetResult(rnext), CancellationToken.None), cancellationToken);
        }
    }
}
