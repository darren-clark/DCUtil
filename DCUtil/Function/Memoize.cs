namespace DCUtil
{
    using System;
    using System.Collections.Generic;

    public static partial class Function
    {
        public static Func<T, TResult> Memoize<T,TResult>(this Func<T,TResult> func)
        {
            var memo = new Dictionary<T, TResult>();
            return arg =>
            {
                TResult result;
                if (!memo.TryGetValue(arg, out result))
                {
                    memo[arg] = result = func(arg);
                }

                return result;
            };
        }

        public static Func<T1, T2, TResult> Memoize<T1, T2, TResult>(this Func<T1, T2, TResult> func)
        {
            return func.Spread().Memoize().Unspread();
        }

        public static Func<T1, T2, T3, TResult> Memoize<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func)
        {
            return func.Spread().Memoize().Unspread();
        }
    }
}
