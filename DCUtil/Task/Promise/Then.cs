namespace DCUtil.Task
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public static partial class TaskExtensions
    {
        public static Task Then(this Task task, Action action, CancellationToken cancellationToken)
        {
            return task.OnSuccessOuter(action, Continuations.ThenVoidSync, cancellationToken);
        }

        public static Task Then(this Task task, Func<Task> action, CancellationToken cancellationToken)
        {
            return task.OnSuccessOuter(action,Continuations.ThenVoidTask, cancellationToken);
        }

        public static Task<TResult> Then<TResult>(this Task task, Func<TResult> action, CancellationToken cancellationToken)
        {
            return task.OnSuccessOuter(action, Continuations.Result<TResult>.ThenResultSync, cancellationToken);
        }

        public static Task<TResult> Then<TResult>(this Task task, Func<Task<TResult>> action, CancellationToken cancellationToken)
        {
            return task.OnSuccessOuter(action, Continuations.Result<TResult>.ThenResultTask, cancellationToken);
        }

        public static Task Then<TIn>(this Task<TIn> task, Action<TIn> action, CancellationToken cancellationToken)
        {
            return task.OnSuccessOuter(action, Continuations.In<TIn>.ThenVoidSync, cancellationToken);
        }

        public static Task Then<TIn>(this Task<TIn> task, Func<TIn, Task> action, CancellationToken cancellationToken)
        {
            return task.OnSuccessOuter(action, Continuations.In<TIn>.ThenVoidTask, cancellationToken);
        }

        public static Task<TResult> Then<TIn, TResult>(this Task<TIn> task, Func<TIn, TResult> action, CancellationToken cancellationToken)
        {
            return task.OnSuccessOuter(action, Continuations.Result<TResult>.In<TIn>.ThenResultSync, cancellationToken);
        }

        public static Task<TResult> Then<TIn, TResult>(this Task<TIn> task, Func<TIn, Task<TResult>> action, CancellationToken cancellationToken)
        {
            return task.OnSuccessOuter(action, Continuations.Result<TResult>.In<TIn>.ThenResultTask, cancellationToken);
        }

        private static partial class Continuations
        {
            public static Action<CompletionContext<VoidResult, Action>> ThenVoidSync = ctx =>
            {
                if (ctx.cancellationToken.IsCancellationRequested)
                {
                    ctx.cancelledAction(ctx);
                }
                else
                {
                    ctx.context();
                    ctx.tcs.SetResult(voidResult);
                }
            };

            public static Action<CompletionContext<VoidResult, Func<Task>>> ThenVoidTask = ctx =>
            {
                if (ctx.cancellationToken.IsCancellationRequested)
                {
                    ctx.cancelledAction(ctx);
                }
                else
                {
                    ctx.context().OnSuccess(null, ctx.tcs, ThenVoidComplete, CancellationToken.None);
                }
            };


            public static Action<CompletionContext<VoidResult, object>> ThenVoidComplete = ctx => ctx.tcs.SetResult(voidResult);

            public static partial class In<TIn>
            {
                public static Action<TIn, CompletionContext<TIn, VoidResult, Action<TIn>>> ThenVoidSync = (result, ctx) =>
                {
                    if (ctx.cancellationToken.IsCancellationRequested)
                    {
                        ctx.cancelledAction(ctx);
                    }
                    else
                    {
                        ctx.context(result);
                        ctx.tcs.SetResult(voidResult);
                    }
                };

                public static Action<TIn, CompletionContext<TIn, VoidResult, Func<TIn, Task>>> ThenVoidTask = (result, ctx) =>
                {
                    if (ctx.cancellationToken.IsCancellationRequested)
                    {
                        ctx.cancelledAction(ctx);
                    }
                    else
                    {
                        ctx.context(result).OnSuccess(null, ctx.tcs, ThenVoidComplete, CancellationToken.None);
                    }
                };
            }

            public static partial class Result<TResult>
            {
                public static Action<CompletionContext<TResult, Func<TResult>>> ThenResultSync = ctx =>
                {
                    if (ctx.cancellationToken.IsCancellationRequested)
                    {
                        ctx.cancelledAction(ctx);
                    }
                    else
                    {
                        ctx.tcs.SetResult(ctx.context());
                    }
                };

                public static Action<CompletionContext<TResult, Func<Task<TResult>>>> ThenResultTask = ctx =>
                {
                    if (ctx.cancellationToken.IsCancellationRequested)
                    {
                        ctx.cancelledAction(ctx);
                    }
                    else
                    {
                        ctx.context().OnSuccess(null, ctx.tcs, ThenResultComplete, CancellationToken.None);
                    }
                };

                public static Action<TResult, CompletionContext<TResult, TResult, object>> ThenResultComplete = (result, ctx) => ctx.tcs.SetResult(result);

                public static partial class In<TIn>
                {
                    public static Action<TIn, CompletionContext<TIn, TResult, Func<TIn, TResult>>> ThenResultSync = (result, ctx) =>
                    {
                        if (ctx.cancellationToken.IsCancellationRequested)
                        {
                            ctx.cancelledAction(ctx);
                        }
                        else
                        {
                            ctx.tcs.SetResult(ctx.context(result));
                        }
                    };

                    public static Action<TIn, CompletionContext<TIn, TResult, Func<TIn, Task<TResult>>>> ThenResultTask = (result, ctx) =>
                    {
                        if (ctx.cancellationToken.IsCancellationRequested)
                        {
                            ctx.cancelledAction(ctx);
                        }
                        else
                        {
                            ctx.context(result).OnSuccess(null, ctx.tcs, ThenResultComplete, CancellationToken.None);
                        }
                    };
                }
            }
        }
    }
}
