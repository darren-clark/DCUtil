namespace DCUtil
{
    using System;
    using System.Threading.Tasks;

    public static partial class FunctionExtensions
    {
        private struct VoidResult
        {
        }

        public static System.Threading.Tasks.Task RunSync(this Action func)
        {
            var tcs = new TaskCompletionSource<VoidResult>();
            try
            {
                func();
                tcs.SetResult(default(VoidResult));
            }
            catch (Exception e)
            {
                tcs.SetException(e);
            }
            return tcs.Task;
        }

        public static Task<TResult> RunSync<TResult>(this Func<TResult> func)
        {
            var tcs = new TaskCompletionSource<TResult>();
            try
            {
                var result = func();
                tcs.SetResult(result);
            } catch(Exception e)
            {
                tcs.SetException(e);
            }
            return tcs.Task;
        }
    }
}
