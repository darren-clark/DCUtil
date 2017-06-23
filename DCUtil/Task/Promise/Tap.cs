namespace DCUtil.Task
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TaskExtensions
    {
        public static Task<T> Tap<T>(this Task<T> task, Action<T> action, CancellationToken cancellationToken)
        {
            return task.OnSuccessOuter(action, Continuations.Result<T>.TapAction, cancellationToken);
        }

        public static Task<T> Tap<T>(this Task<T> task, Func<T, Task> action, CancellationToken cancellationToken)
        {
            return task.OnSuccessOuter(action, Continuations.Result<T>.TapTask, cancellationToken);
        }

        public static Task<T> Tap<T, TDummy>(this Task<T> task, Func<T, TDummy> action, CancellationToken cancellationToken)
        {
            return task.OnSuccessOuter(action, Continuations.Result<T>.Dummy<TDummy>.TapAction, cancellationToken);
        }

        public static Task<T> Tap<T, TDummy>(this Task<T> task, Func<T, Task<TDummy>> action, CancellationToken cancellationToken)
        {
            return task.OnSuccessOuter(action, Continuations.Result<T>.Dummy<TDummy>.TapTask, cancellationToken);
        }

        private static partial class Continuations
        {
            public static partial class Result<TResult>
            {
                public static Action<TResult, CompletionContext<TResult, TResult, Action<TResult>>> TapAction = (r, ctx) =>
                {
                    if (ctx.cancellationToken.IsCancellationRequested)
                    {
                        ctx.cancelledAction(ctx);
                    }
                    else
                    {
                        ctx.context(r);
                        ctx.tcs.SetResult(r);
                    }
                };

                public static Action<TResult, CompletionContext<TResult, TResult, Func<TResult, Task>>> TapTask = (r, ctx) =>
                {
                    if (ctx.cancellationToken.IsCancellationRequested)
                    {
                        ctx.cancelledAction(ctx);
                    }
                    else
                    {
                        ctx.context(r).OnSuccess(r, ctx.tcs, TapComplete, CancellationToken.None);

                    }
                };

                public static Action<CompletionContext<TResult, TResult>> TapComplete = (ctx) => ctx.tcs.SetResult(ctx.context);

                public static partial class Dummy<TDummy>
                {
                    public static Action<TResult, CompletionContext<TResult, TResult, Func<TResult, TDummy>>> TapAction = (r, ctx) =>
                    {
                        if (ctx.cancellationToken.IsCancellationRequested)
                        {
                            ctx.cancelledAction(ctx);
                        }
                        else
                        {
                            ctx.context(r);
                            ctx.tcs.SetResult(r);
                        }
                    };

                    public static Action<TResult, CompletionContext<TResult, TResult, Func<TResult, Task<TDummy>>>> TapTask = (r, ctx) =>
                    {
                        if (ctx.cancellationToken.IsCancellationRequested)
                        {
                            ctx.cancelledAction(ctx);
                        }
                        else
                        {
                            ctx.context(r).OnSuccess(r, ctx.tcs, TapComplete, CancellationToken.None);
                        }
                    };
                }
            }
        }

    }
}
