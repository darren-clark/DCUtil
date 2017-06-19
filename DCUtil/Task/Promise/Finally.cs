namespace DCUtil.Task
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public static partial class TaskExtensions
    {
        private static partial class Continuations
        {
            public static Action<CompletionContext<VoidResult, Action>> FinallySuccess = ctx =>
                {
                    ctx.context();
                    ctx.tcs.SetResult(voidResult);
                };

            public static Action<Exception, CompletionContext<VoidResult, Action>> FinallyFaulted = (e, ctx) =>
                {
                    ctx.context();
                    ctx.tcs.SetException(e);
                };

            public static Action<CompletionContext<VoidResult, Action>> FinallyCanceled = ctx =>
                {
                    ctx.context();
                    ctx.tcs.SetCanceled();
                };

            public static Action<CompletionContext<VoidResult, Func<Task>>> FinallyTaskSuccess = ctx =>
                ctx.context().OnSuccess(null, ctx.tcs, ThenVoidComplete, CancellationToken.None);

            public static Action<Exception, CompletionContext<VoidResult, Func<Task>>> FinallyTaskFaulted =(e,ctx) =>
                ctx.context().OnSuccess(e, ctx.tcs, FinallyTaskFaultedComplete, CancellationToken.None);

            public static Action<CompletionContext<VoidResult, Func<Task>>> FinallyTaskCancelled = (ctx) =>
                ctx.context().OnSuccess(null, ctx.tcs, FinallyTaskCancelledComplete, CancellationToken.None);

            public static Action<CompletionContext<VoidResult, Exception>> FinallyTaskFaultedComplete = ctx =>
                ctx.tcs.SetException(ctx.context);

            public static Action<CompletionContext<VoidResult, object>> FinallyTaskCancelledComplete = ctx =>
                ctx.tcs.SetCanceled();

            public static partial class Result<TResult>
            {
                public static Action<TResult, CompletionContext<TResult,TResult, Action>> FinallySuccess = (r,ctx) =>
                {
                    ctx.context();
                    ctx.tcs.SetResult(r);
                };

                public static Action<Exception, CompletionContext<TResult, TResult, Action>> FinallyFaulted = (e, ctx) =>
                {
                    ctx.context();
                    ctx.tcs.SetException(e);
                };

                public static Action<CompletionContext<TResult, TResult, Action>> FinallyCanceled = ctx =>
                {
                    ctx.context();
                    ctx.tcs.SetCanceled();
                };

                public static Action<TResult, CompletionContext<TResult, TResult, Func<Task>>> FinallyTaskSuccess =(r, ctx) =>
                    ctx.context().OnSuccess(r, ctx.tcs, TapComplete, CancellationToken.None);

                public static Action<Exception, CompletionContext<TResult, TResult, Func<Task>>> FinallyTaskFaulted = (e, ctx) =>
                     ctx.context().OnSuccess(e, ctx.tcs, FinallyTaskFaultedComplete, CancellationToken.None);

                public static Action<CompletionContext<TResult,TResult, Func<Task>>> FinallyTaskCancelled = (ctx) =>
                    ctx.context().OnSuccess(null, ctx.tcs, FinallyTaskCancelledComplete, CancellationToken.None);

                public static Action<CompletionContext<TResult, Exception>> FinallyTaskFaultedComplete = ctx =>
                    ctx.tcs.SetException(ctx.context);

                public static Action<CompletionContext<TResult, object>> FinallyTaskCancelledComplete = ctx =>
                    ctx.tcs.SetCanceled();

            }
        }

        public static Task Finally(this Task task, Action action)
        {
            var tcs = new TaskCompletionSource<VoidResult>();
            task.OnCompletion(action, tcs, Continuations.FinallySuccess, Continuations.FinallyFaulted, Continuations.FinallyCanceled, CancellationToken.None);
            return tcs.Task;
        }

        public static Task Finally(this Task task, Func<Task> action)
        {
            var tcs = new TaskCompletionSource<VoidResult>();
            task.OnCompletion(action, tcs, Continuations.FinallyTaskSuccess, Continuations.FinallyTaskFaulted, Continuations.FinallyTaskCancelled, CancellationToken.None);
            return tcs.Task;
        }

        public static Task<TResult> Finally<TResult>(this Task<TResult> task, Action action)
        {
            var tcs = new TaskCompletionSource<TResult>();
            task.OnCompletion(action, tcs, Continuations.Result<TResult>.FinallySuccess, Continuations.Result<TResult>.FinallyFaulted, Continuations.Result<TResult>.FinallyCanceled, CancellationToken.None);
            return tcs.Task;
        }

        public static Task<TResult> Finally<TResult>(this Task<TResult> task, Func<Task> action)
        {
            var tcs = new TaskCompletionSource<TResult>();
            task.OnCompletion(action, tcs, Continuations.Result<TResult>.FinallyTaskSuccess, Continuations.Result<TResult>.FinallyTaskFaulted, Continuations.Result<TResult>.FinallyTaskCancelled, CancellationToken.None);
            return tcs.Task;
        }
    }
}
