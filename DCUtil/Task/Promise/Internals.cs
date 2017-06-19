namespace DCUtil.Task
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public static partial class TaskExtensions
    {
        private static partial class Continuations
        {
            public static partial class Result<TResult>
            {
                public static partial class Context<TContext>
                {
                    public static Action<Exception, CompletionContext<TResult, TContext>> DefaultFaulted = (e, ctx) => ctx.tcs.SetException(e);
                    public static Action<CompletionContext<TResult, TContext>> DefaultCanceled = ctx => ctx.tcs.SetCanceled();
                }

                public static partial class In<TIn>
                {
                    public static partial class Context<TContext>
                    {
                        public static Action<Exception, CompletionContext<TIn, TResult, TContext>> DefaultFaulted = (e, ctx) => ctx.tcs.SetException(e);
                        public static Action<CompletionContext<TIn, TResult, TContext>> DefaultCanceled = ctx => ctx.tcs.SetCanceled();
                    }
                }
            }
        }

        private struct CompletionContext<TResult, TContext>
        {
            public TContext context;
            public TaskCompletionSource<TResult> tcs;
            public CancellationToken cancellationToken;
            public Action<CompletionContext<TResult, TContext>> successAction;
            public Action<Exception, CompletionContext<TResult, TContext>> faultedAction;
            public Action<CompletionContext<TResult, TContext>> cancelledAction;
        }

        private struct CompletionContext<TIn, TResult, TContext>
        {
            public TContext context;
            public TaskCompletionSource<TResult> tcs;
            public CancellationToken cancellationToken;
            public Action<TIn, CompletionContext<TIn, TResult, TContext>> successAction;
            public Action<Exception, CompletionContext<TIn, TResult, TContext>> faultedAction;
            public Action<CompletionContext<TIn, TResult, TContext>> cancelledAction;
        }

        private static void OnCompletionContination<TResult,TContext>(Task t, object boxedCtx)
        {
            var ctx = (CompletionContext<TResult, TContext>)boxedCtx;
            try
            {
                switch (t.Status)
                {
                    case TaskStatus.RanToCompletion:
                        ctx.successAction(ctx);
                        break;
                    case TaskStatus.Faulted:
                        ctx.faultedAction(t.Exception, ctx);
                        break;
                    case TaskStatus.Canceled:
                        ctx.cancelledAction(ctx);
                        break;
                }
            }
            catch (Exception e)
            {
                ctx.tcs.SetException(e);
            }
        }

        private static void OnCompletionContination<TIn, TResult, TContext>(Task<TIn> t, object boxedCtx)
        {
            var ctx = (CompletionContext<TIn, TResult, TContext>)boxedCtx;
            try
            {
                switch (t.Status)
                {
                    case TaskStatus.RanToCompletion:
                        ctx.successAction(t.Result, ctx);
                        break;
                    case TaskStatus.Faulted:
                        ctx.faultedAction(t.Exception, ctx);
                        break;
                    case TaskStatus.Canceled:
                        ctx.cancelledAction(ctx);
                        break;
                }
            }
            catch (Exception e)
            {
                ctx.tcs.SetException(e);
            }
        }

        private static void OnCompletion<TResult, TContext>(this Task task, TContext context,  TaskCompletionSource<TResult> tcs, Action<CompletionContext<TResult,TContext>> successAction, Action<Exception, CompletionContext<TResult, TContext>> faultedAction, Action<CompletionContext<TResult, TContext>> cancelledAction, CancellationToken cancellationToken)
        {
            task.ContinueWith(OnCompletionContination<TResult, TContext>, new CompletionContext<TResult, TContext> { context = context, tcs = tcs, cancellationToken = cancellationToken, successAction = successAction, faultedAction = faultedAction, cancelledAction = cancelledAction } );
        }

        private static void OnCompletion<TIn, TResult, TContext>(this Task<TIn> task, TContext context, TaskCompletionSource<TResult> tcs, Action<TIn, CompletionContext<TIn, TResult, TContext>> successAction, Action<Exception, CompletionContext<TIn, TResult, TContext>> faultedAction, Action<CompletionContext<TIn, TResult, TContext>> cancelledAction, CancellationToken cancellationToken)
        {
            task.ContinueWith(OnCompletionContination<TIn,TResult, TContext>, new CompletionContext<TIn,TResult, TContext> { context = context, tcs = tcs, cancellationToken = cancellationToken,  successAction = successAction, faultedAction = faultedAction, cancelledAction = cancelledAction });
        }

        private static void OnSuccess<TResult, TContext>(this Task task, TContext context, TaskCompletionSource<TResult> tcs, Action<CompletionContext<TResult, TContext>> successAction, CancellationToken cancellationToken)
        {
            task.OnCompletion(context, tcs , successAction, Continuations.Result<TResult>.Context<TContext>.DefaultFaulted, Continuations.Result<TResult>.Context<TContext>.DefaultCanceled, cancellationToken);
        }

        private static void OnSuccess<TIn, TResult, TContext>(this Task<TIn> task, TContext context, TaskCompletionSource<TResult> tcs, Action<TIn, CompletionContext<TIn, TResult, TContext>> successAction, CancellationToken cancellationToken)
        {
            task.OnCompletion(context, tcs, successAction, Continuations.Result<TResult>.In<TIn>.Context<TContext>.DefaultFaulted, Continuations.Result<TResult>.In<TIn>.Context<TContext>.DefaultCanceled, cancellationToken);
        }

        private static Task<TResult> OnSuccess<TResult, TContext>(this Task task, TContext context, Action<CompletionContext<TResult, TContext>> completionAction, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<TResult>();
            task.OnSuccess(context, tcs, completionAction, cancellationToken);
            return tcs.Task;
        }

        private static Task<TResult> OnSuccess<TIn, TResult, TContext>(this Task<TIn> task, TContext context, Action<TIn, CompletionContext<TIn, TResult, TContext>> completionAction, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<TResult>();
            task.OnSuccess(context, tcs, completionAction, cancellationToken);
            return tcs.Task;
        }
    }
}
