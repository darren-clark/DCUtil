
namespace DCUtil
{
	using System;
	using System.Collections.Generic;

	public static partial class FunctionExtensions
	{
        public static Func<T, TResult> Memoize<T,TResult>(this Func<T,TResult> func)
        {
            var memo = new Dictionary<T, TResult>();
            return arg =>
            {
                if (!memo.TryGetValue(arg, out TResult result))
                {
                    memo[arg] = result = func(arg);
                }

                return result;
            };
        }
		public static Func<T1,T2,TResult> Memoize<T1,T2,TResult>(this Func<T1,T2,TResult> func)
		{
			return func.Spread().Memoize().Unspread();
		}
		public static Func<T1,T2,T3,TResult> Memoize<T1,T2,T3,TResult>(this Func<T1,T2,T3,TResult> func)
		{
			return func.Spread().Memoize().Unspread();
		}
		public static Func<T1,T2,T3,T4,TResult> Memoize<T1,T2,T3,T4,TResult>(this Func<T1,T2,T3,T4,TResult> func)
		{
			return func.Spread().Memoize().Unspread();
		}
		public static Func<T1,T2,T3,T4,T5,TResult> Memoize<T1,T2,T3,T4,T5,TResult>(this Func<T1,T2,T3,T4,T5,TResult> func)
		{
			return func.Spread().Memoize().Unspread();
		}
		public static Func<T1,T2,T3,T4,T5,T6,TResult> Memoize<T1,T2,T3,T4,T5,T6,TResult>(this Func<T1,T2,T3,T4,T5,T6,TResult> func)
		{
			return func.Spread().Memoize().Unspread();
		}
		public static Func<T1,T2,T3,T4,T5,T6,T7,TResult> Memoize<T1,T2,T3,T4,T5,T6,T7,TResult>(this Func<T1,T2,T3,T4,T5,T6,T7,TResult> func)
		{
			return func.Spread().Memoize().Unspread();
		}
	}
}