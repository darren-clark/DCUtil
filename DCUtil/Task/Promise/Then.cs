namespace DCUtil.Task
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public static partial class TaskExtensions
    {
        private static partial class Continuations
        {
            public static Action<Action, TaskCompletionSource<VoidResult>> ThenVoidSync = (action, tcs) =>
            {
                action();
                tcs.SetResult(voidResult);
            };

            public static Action<Func<Task>, TaskCompletionSource<VoidResult>> ThenVoidTask = (action, tcs) =>
                action().OnSuccess(null, tcs, ThenVoidComplete, CancellationToken.None);

            public static Action<object, TaskCompletionSource<VoidResult>> ThenVoidComplete = (dummy, tcs) => tcs.SetResult(voidResult);
        }

        private static partial class Continuations<T>
        {
            public static Action<Func<T>, TaskCompletionSource<T>> ThenResultSync = (action, tcs) => tcs.SetResult(action());

            public static Action<Func<Task<T>>, TaskCompletionSource<T>> ThenResultTask = (action, tcs) =>
                action().OnSuccess(null, tcs, ThenResultComplete, CancellationToken.None);

            public static Action<T, object, TaskCompletionSource<T>> ThenResultComplete = (result,dummy, tcs) => tcs.SetResult(result);

            public static Action<T, Action<T>, TaskCompletionSource<VoidResult>> ThenVoidSync = (result, action, tcs) =>
                {
                    action(result);
                    tcs.SetResult(voidResult);
                };

            public static Action<T, Func<T, Task>, TaskCompletionSource<VoidResult>> ThenVoidTask = (result, action, tcs) =>
                action(result).OnSuccess(null, Continuations.ThenVoidComplete, CancellationToken.None);

        }

        
        public static Task Then(this Task task, Action action, CancellationToken cancellationToken)
        {
            return task.OnSuccess(action, Continuations.ThenVoidSync, cancellationToken);
        }

        public static Task Then(this Task task, Func<Task> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess(action,Continuations.ThenVoidTask, cancellationToken);
        }

        public static Task<TResult> Then<TResult>(this Task task, Func<TResult> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess(action, Continuations<TResult>.ThenResultSync, cancellationToken);
        }

        public static Task<TResult> Then<TResult>(this Task task, Func<Task<TResult>> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess(action, Continuations<TResult>.ThenResultTask, cancellationToken);
        }

        public static Task Then<TIn>(this Task<TIn> task, Action<TIn> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess(action, Continuations<TIn>.ThenVoidSync, cancellationToken);
        }

        public static Task Then<TIn>(this Task<TIn> task, Func<TIn, Task> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess(action, Continuations<TIn>.ThenVoidTask, cancellationToken);
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
