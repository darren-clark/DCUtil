namespace DCUtil.Task
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TaskExtensions
    {
        private static void DefaultFaulted<TResult,TContext>( Exception e, CompletionContext<TResult, TContext> ctx) => ctx.tcs.SetException(e);
        private static void DefaultCanceled<TResult,TContext>(CompletionContext<TResult, TContext> ctx) => ctx.tcs.SetCanceled();
        private static void DefaultFaulted<TResult, TContext>(Exception e, TContext ctx, TaskCompletionSource<TResult> tcs) => tcs.SetException(e);
        private static void DefaultCanceled<TResult, TContext>(TContext ctx, TaskCompletionSource<TResult> tcs) => tcs.SetCanceled();
        //private static void DefaultSuccess<TResult>(Task<TResult> t, TaskCompletionSource<TResult> tcs) => tcs.SetResult(t.Result);
        //private static void DefaultSuccess(Task t, TaskCompletionSource<VoidResult> tcs) => tcs.SetResult(voidResult);

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
            public Action<TIn, TContext, TaskCompletionSource<TResult>> successAction;
            public Action<Exception, TContext, TaskCompletionSource<TResult>> faultedAction;
            public Action<TContext, TaskCompletionSource<TResult>> cancelledAction;
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
                        ctx.successAction(t.Result, ctx.context, ctx.tcs);
                        break;
                    case TaskStatus.Faulted:
                        ctx.faultedAction(t.Exception, ctx.context, ctx.tcs);
                        break;
                    case TaskStatus.Canceled:
                        ctx.cancelledAction(ctx.context, ctx.tcs);
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

        private static void OnCompletion<TIn, TResult, TContext>(this Task<TIn> task, TContext context, TaskCompletionSource<TResult> tcs, Action<TIn, TContext, TaskCompletionSource<TResult>> successAction, Action<Exception, TContext, TaskCompletionSource<TResult>> faultedAction, Action<TContext, TaskCompletionSource<TResult>> cancelledAction, CancellationToken cancellationToken)
        {
            task.ContinueWith(OnCompletionContination<TIn,TResult, TContext>, new CompletionContext<TIn,TResult, TContext> { context = context, tcs = tcs, cancellationToken = cancellationToken,  successAction = successAction, faultedAction = faultedAction, cancelledAction = cancelledAction });
        }

        private static void OnSuccess<TResult, TContext>(this Task task, TContext context, TaskCompletionSource<TResult> tcs, Action<CompletionContext<TResult, TContext>> successAction, CancellationToken cancellationToken)
        {
            task.OnCompletion(context, tcs , successAction, DefaultFaulted, DefaultCanceled, cancellationToken);
        }

        private static void OnSuccess<TIn, TResult, TContext>(this Task<TIn> task, TContext context, TaskCompletionSource<TResult> tcs, Action<TIn, TContext, TaskCompletionSource<TResult>> successAction, CancellationToken cancellationToken)
        {
            task.OnCompletion(context, tcs, successAction, DefaultFaulted, DefaultCanceled, cancellationToken);
        }

        private static Task<TResult> OnSuccess<TResult, TContext>(this Task task, TContext context, Action<CompletionContext<TResult, TContext>> completionAction, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<TResult>();
            task.OnSuccess(context, tcs, completionAction, cancellationToken);
            return tcs.Task;
        }

        private static Task<TResult> OnSuccess<TIn, TResult, TContext>(this Task<TIn> task, TContext context, Action<TIn, TContext, TaskCompletionSource<TResult>> completionAction, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<TResult>();
            task.OnSuccess(context, tcs, completionAction, cancellationToken);
            return tcs.Task;
        }
    }
}
