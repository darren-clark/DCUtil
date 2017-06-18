namespace DCUtil.Task
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public static partial class TaskExtensions
    {
        public static Task Then(this Task task, Action action, CancellationToken cancellationToken)
        {
            return task.OnSuccess<VoidResult,Action>(action, (ctx, tcs) => { ctx(); tcs.SetResult(voidResult); }, cancellationToken);
        }

        public static Task Then(this Task task, Func<Task> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess<VoidResult,Func<Task>>(action, (ctx, tcs) => ctx().OnSuccess<VoidResult, object>(null, tcs,(t, next) => next.SetResult(voidResult), CancellationToken.None), cancellationToken);
        }

        public static Task<TResult> Then<TResult>(this Task task, Func<TResult> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess<TResult, Func<TResult>>(action, (ctx, tcs) => tcs.SetResult(ctx()), cancellationToken);
        }

        public static Task<TResult> Then<TResult>(this Task task, Func<Task<TResult>> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess<TResult, Func<Task<TResult>>>(action, (ctx, tcs) => ctx().OnSuccess<TResult, TResult,object>(null, tcs, (r, n, next) => next.SetResult(r), CancellationToken.None), cancellationToken);
        }

        public static Task Then<TIn>(this Task<TIn> task, Action<TIn> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess<TIn, VoidResult, Action<TIn>>(action, (r,ctx, tcs) => { ctx(r); tcs.SetResult(voidResult); }, cancellationToken);
        }

        public static Task Then<TIn>(this Task<TIn> task, Func<TIn, Task> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess<TIn, VoidResult,Func<TIn,Task>>(action, (r,ctx, tcs) => ctx(r).OnSuccess<VoidResult,object>(null, tcs, (n ,next) => next.SetResult(voidResult), CancellationToken.None), cancellationToken);
        }

        public static Task<TResult> Then<TIn, TResult>(this Task<TIn> task, Func<TIn, TResult> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess<TIn, TResult, Func<TIn, TResult>>(action, (r, ctx, tcs) => tcs.SetResult(ctx(r)), cancellationToken);
        }

        public static Task<TResult> Then<TIn, TResult>(this Task<TIn> task, Func<TIn, Task<TResult>> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess<TIn, TResult, Func<TIn,Task<TResult>>>(action, (r, ctx, tcs) => ctx(r).OnSuccess<TResult,TResult, object>(null, tcs, (rnext, n, tcsnext) => tcsnext.SetResult(rnext), CancellationToken.None), cancellationToken);
        }

        public static Task Then(this Task task, Action action)
        {
            return task.Then(action, CancellationToken.None);
        }

        public static Task Then(this Task task, Func<Task> action)
        {
            return task.Then(action, CancellationToken.None);
        }

        public static Task<TOut> Then<TOut>(this Task task, Func<TOut> action)
        {
            return task.Then(action, CancellationToken.None);
        }
    }
}
