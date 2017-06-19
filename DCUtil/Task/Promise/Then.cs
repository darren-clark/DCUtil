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

            public static partial class In<TIn>
            {
                public static Action<TIn, Action<TIn>, TaskCompletionSource<VoidResult>> ThenVoidSync = (result, action, tcs) =>
                {
                    action(result);
                    tcs.SetResult(voidResult);
                };

                public static Action<TIn, Func<TIn, Task>, TaskCompletionSource<VoidResult>> ThenVoidTask = (result, action, tcs) =>
                    action(result).OnSuccess(null, ThenVoidComplete, CancellationToken.None);
            }

            public static partial class Result<TResult>
            {
                public static Action<Func<TResult>, TaskCompletionSource<TResult>> ThenResultSync = (action, tcs) => tcs.SetResult(action());

                public static Action<Func<Task<TResult>>, TaskCompletionSource<TResult>> ThenResultTask = (action, tcs) =>
                    action().OnSuccess(null, tcs, ThenResultComplete, CancellationToken.None);

                public static Action<TResult, object, TaskCompletionSource<TResult>> ThenResultComplete = (result, dummy, tcs) => tcs.SetResult(result);

                public static partial class In<TIn>
                {
                    public static Action<TIn, Func<TIn, TResult>, TaskCompletionSource<TResult>> ThenResultSync = (result, action, tcs) =>
                         tcs.SetResult(action(result));

                    public static Action<TIn, Func<TIn, Task<TResult>>, TaskCompletionSource<TResult>> ThenResultTask = (result, action, tcs) =>
                        action(result).OnSuccess(null, ThenResultComplete, CancellationToken.None);
                }
            }
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
            return task.OnSuccess(action, Continuations.Result<TResult>.ThenResultSync, cancellationToken);
        }

        public static Task<TResult> Then<TResult>(this Task task, Func<Task<TResult>> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess(action, Continuations.Result<TResult>.ThenResultTask, cancellationToken);
        }

        public static Task Then<TIn>(this Task<TIn> task, Action<TIn> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess(action, Continuations.In<TIn>.ThenVoidSync, cancellationToken);
        }

        public static Task Then<TIn>(this Task<TIn> task, Func<TIn, Task> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess(action, Continuations.In<TIn>.ThenVoidTask, cancellationToken);
        }

        public static Task<TResult> Then<TIn, TResult>(this Task<TIn> task, Func<TIn, TResult> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess<TIn, TResult, Func<TIn, TResult>>(action, Continuations.Result<TResult>.In<TIn>.ThenResultSync, cancellationToken);
        }

        public static Task<TResult> Then<TIn, TResult>(this Task<TIn> task, Func<TIn, Task<TResult>> action, CancellationToken cancellationToken)
        {
            return task.OnSuccess<TIn, TResult, Func<TIn,Task<TResult>>>(action, Continuations.Result<TResult>.In<TIn>.ThenResultTask, cancellationToken);
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
