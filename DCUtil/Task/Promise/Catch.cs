namespace DCUtil.Task
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public static partial class TaskExtensions
    {
        public static Task Catch(this Task task, Action<Exception> onException)
        {
            return task.OnCompletionOuter(onException, Continuations.CatchComplete, Continuations.CatchFaulted, Continuations.CatchCanceled, CancellationToken.None);
        }

        public static Task Catch(this Task task, Func<Exception, Task> onException)
        {
            return task.OnCompletionOuter(onException, Continuations.CatchTaskComplete, Continuations.CatchTaskFaulted, Continuations.CatchTaskCanceled, CancellationToken.None);
        }

        public static Task<TResult> Catch<TResult>(this Task<TResult> task, Action<Exception> onException)
        {
            return task.OnCompletionOuter(onException, Continuations.Result<TResult>.CatchComplete, Continuations.Result<TResult>.CatchFaulted, Continuations.Result<TResult>.CatchCanceled, CancellationToken.None);
        }

        public static Task<TResult> Catch<TResult>(this Task<TResult> task, Func<Exception, Task> onException)
        {
            return task.OnCompletionOuter(onException, Continuations.Result<TResult>.CatchTaskComplete, Continuations.Result<TResult>.CatchTaskFaulted, Continuations.Result<TResult>.CatchTaskCanceled, CancellationToken.None);
        }

        public static Task<TResult> Catch<TResult>(this Task<TResult> task, Func<Exception, TResult> onException)
        {
            return task.OnCompletionOuter(onException, Continuations.Result<TResult>.CatchResultComplete, Continuations.Result<TResult>.CatchResultFaulted, Continuations.Result<TResult>.CatchResultCanceled, CancellationToken.None);
        }

        public static Task<TResult> Catch<TResult>(this Task<TResult> task, Func<Exception, Task<TResult>> onException)
        {
            return task.OnCompletionOuter(onException, Continuations.Result<TResult>.CatchResultTaskComplete, Continuations.Result<TResult>.CatchResultTaskFaulted, Continuations.Result<TResult>.CatchResultTaskCanceled, CancellationToken.None);
        }

        private static partial class Continuations
        {
            public static Action<CompletionContext<VoidResult, Action<Exception>>> CatchComplete =
                ctx => ctx.tcs.SetResult(voidResult);

            public static Action<Exception, CompletionContext<VoidResult, Action<Exception>>> CatchFaulted = (e, ctx) =>
            {
                ctx.context(e);
                ctx.tcs.SetResult(voidResult);
            };

            public static Action<CompletionContext<VoidResult, Action<Exception>>> CatchCanceled = ctx =>
            {
                ctx.context(new TaskCanceledException(ctx.task));
                ctx.tcs.SetResult(voidResult);
            };

            public static Action<CompletionContext<VoidResult, Func<Exception, Task>>> CatchTaskComplete =
                ctx => ctx.tcs.SetResult(voidResult);

            public static Action<Exception, CompletionContext<VoidResult, Func<Exception, Task>>> CatchTaskFaulted = (e, ctx) =>
            {
                ctx.context(e).OnSuccess(null, ctx.tcs, ThenVoidComplete, CancellationToken.None);
            };

            public static Action<CompletionContext<VoidResult, Func<Exception, Task>>> CatchTaskCanceled = ctx =>
            {
                ctx.context(new TaskCanceledException(ctx.task)).OnSuccess(null, ctx.tcs, ThenVoidComplete, CancellationToken.None);
            };

            public static partial class Result<TResult>
            {
                public static Action<TResult, CompletionContext<TResult, TResult, Action<Exception>>> CatchComplete =
                    (r, ctx) => ctx.tcs.SetResult(r);

                public static Action<Exception, CompletionContext<TResult, TResult, Action<Exception>>> CatchFaulted = (e, ctx) =>
                {
                    ctx.context(e);
                    ctx.tcs.SetResult(default(TResult));
                };

                public static Action<CompletionContext<TResult, TResult, Action<Exception>>> CatchCanceled = ctx =>
                {
                    ctx.context(new TaskCanceledException(ctx.task));
                    ctx.tcs.SetResult(default(TResult));
                };

                public static Action<TResult, CompletionContext<TResult, TResult, Func<Exception, Task>>> CatchTaskComplete =
                    (r, ctx) => ctx.tcs.SetResult(r);

                public static Action<Exception, CompletionContext<TResult, TResult, Func<Exception, Task>>> CatchTaskFaulted = (e, ctx) =>
                    ctx.context(e).OnSuccess(default(TResult), ctx.tcs, TapComplete, CancellationToken.None);

                public static Action<CompletionContext<TResult, TResult, Func<Exception, Task>>> CatchTaskCanceled = ctx =>
                    ctx.context(new TaskCanceledException(ctx.task)).OnSuccess(default(TResult), ctx.tcs, TapComplete, CancellationToken.None);

                public static Action<TResult, CompletionContext<TResult, TResult, Func<Exception, TResult>>> CatchResultComplete =
                    (r, ctx) => ctx.tcs.SetResult(r);

                public static Action<Exception, CompletionContext<TResult, TResult, Func<Exception, TResult>>> CatchResultFaulted = (e, ctx) =>
                    ctx.tcs.SetResult(ctx.context(e));

                public static Action<CompletionContext<TResult, TResult, Func<Exception, TResult>>> CatchResultCanceled = ctx =>
                    ctx.tcs.SetResult(ctx.context(new TaskCanceledException(ctx.task)));

                public static Action<TResult, CompletionContext<TResult, TResult, Func<Exception, Task<TResult>>>> CatchResultTaskComplete =
                    (r, ctx) => ctx.tcs.SetResult(r);

                public static Action<Exception, CompletionContext<TResult, TResult, Func<Exception, Task<TResult>>>> CatchResultTaskFaulted =
                    (e, ctx) => ctx.context(e).OnSuccess(null, ctx.tcs, ThenResultComplete, CancellationToken.None);

                public static Action<CompletionContext<TResult, TResult, Func<Exception, Task<TResult>>>> CatchResultTaskCanceled =
                    ctx => ctx.context(new TaskCanceledException(ctx.task)).OnSuccess(null, ctx.tcs, ThenResultComplete, CancellationToken.None);
            }
        }

    }
}
