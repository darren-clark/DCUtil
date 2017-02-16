namespace DCUtil
{
    using System;
    using System.Threading.Tasks;

    public static partial class Function
    {
        private struct Protected
        {
        }

        public static Task AsTask(this Action func)
        {
            var tcs = new TaskCompletionSource<Protected>();
            try
            {
                func();
                tcs.SetResult(default(Protected));
            }
            catch (Exception e)
            {
                tcs.SetException(e);
            }
            return tcs.Task;
        }

        public static Task<TResult> AsTask<TResult>(this Func<TResult> func)
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
