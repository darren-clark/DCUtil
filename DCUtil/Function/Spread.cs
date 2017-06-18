
namespace DCUtil
{
	using System;

	public static partial class FunctionExtensions
	{
		public static Func<Tuple<T1>, TResult> Spread<T1,TResult>(this Func<T1,TResult> func)
		{
			return func.Apply;
		}
		public static Action<Tuple<T1>> Spread<T1>(this Action<T1> func)
		{
			return func.Apply;
		}
		public static Func<Tuple<T1,T2>, TResult> Spread<T1,T2,TResult>(this Func<T1,T2,TResult> func)
		{
			return func.Apply;
		}
		public static Action<Tuple<T1,T2>> Spread<T1,T2>(this Action<T1,T2> func)
		{
			return func.Apply;
		}
		public static Func<Tuple<T1,T2,T3>, TResult> Spread<T1,T2,T3,TResult>(this Func<T1,T2,T3,TResult> func)
		{
			return func.Apply;
		}
		public static Action<Tuple<T1,T2,T3>> Spread<T1,T2,T3>(this Action<T1,T2,T3> func)
		{
			return func.Apply;
		}
		public static Func<Tuple<T1,T2,T3,T4>, TResult> Spread<T1,T2,T3,T4,TResult>(this Func<T1,T2,T3,T4,TResult> func)
		{
			return func.Apply;
		}
		public static Action<Tuple<T1,T2,T3,T4>> Spread<T1,T2,T3,T4>(this Action<T1,T2,T3,T4> func)
		{
			return func.Apply;
		}
		public static Func<Tuple<T1,T2,T3,T4,T5>, TResult> Spread<T1,T2,T3,T4,T5,TResult>(this Func<T1,T2,T3,T4,T5,TResult> func)
		{
			return func.Apply;
		}
		public static Action<Tuple<T1,T2,T3,T4,T5>> Spread<T1,T2,T3,T4,T5>(this Action<T1,T2,T3,T4,T5> func)
		{
			return func.Apply;
		}
		public static Func<Tuple<T1,T2,T3,T4,T5,T6>, TResult> Spread<T1,T2,T3,T4,T5,T6,TResult>(this Func<T1,T2,T3,T4,T5,T6,TResult> func)
		{
			return func.Apply;
		}
		public static Action<Tuple<T1,T2,T3,T4,T5,T6>> Spread<T1,T2,T3,T4,T5,T6>(this Action<T1,T2,T3,T4,T5,T6> func)
		{
			return func.Apply;
		}
		public static Func<Tuple<T1,T2,T3,T4,T5,T6,T7>, TResult> Spread<T1,T2,T3,T4,T5,T6,T7,TResult>(this Func<T1,T2,T3,T4,T5,T6,T7,TResult> func)
		{
			return func.Apply;
		}
		public static Action<Tuple<T1,T2,T3,T4,T5,T6,T7>> Spread<T1,T2,T3,T4,T5,T6,T7>(this Action<T1,T2,T3,T4,T5,T6,T7> func)
		{
			return func.Apply;
		}
	}
}