
using System;

namespace DCUtil
{
    public  static partial class FunctionExtensions
    {
        public static Func<TResult> Tap<TResult>(this Func<TResult> function, Action<TResult> action)
        {
            return () =>
            {
                var result = function();
                action(result);
                return result;
            };
        }

        public static Func<T1,TResult> Tap<T1,TResult>(this Func<T1, TResult> function, Action<TResult> action)
        {
            return t1 =>
            {
                var result = function(t1);
                action(result);
                return result;
            };
        }

        public static Func<T1, TResult> Tap<T1, TResult>(this Func<T1, TResult> function, Action<T1,TResult> action)
        {
            return t1 =>
            {
                var result = function(t1);
                action(t1,result);
                return result;
            };
        }

    }
}
