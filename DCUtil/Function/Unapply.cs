
namespace DCUtil
{
	using System;

	public static partial class FunctionExtensions
	{
		public static TResult Unapply<T1,TResult>(this Func<Tuple<T1>, TResult> func, T1 arg1)
		{
			return func(Tuple.Create(arg1));
		}
		public static void Unapply<T1>(this Action<Tuple<T1>> func, T1 arg1)
		{
			func(Tuple.Create(arg1));
		}
		public static TResult Unapply<T1,T2,TResult>(this Func<Tuple<T1,T2>, TResult> func, T1 arg1, T2 arg2)
		{
			return func(Tuple.Create(arg1, arg2));
		}
		public static void Unapply<T1,T2>(this Action<Tuple<T1,T2>> func, T1 arg1, T2 arg2)
		{
			func(Tuple.Create(arg1, arg2));
		}
		public static TResult Unapply<T1,T2,T3,TResult>(this Func<Tuple<T1,T2,T3>, TResult> func, T1 arg1, T2 arg2, T3 arg3)
		{
			return func(Tuple.Create(arg1, arg2, arg3));
		}
		public static void Unapply<T1,T2,T3>(this Action<Tuple<T1,T2,T3>> func, T1 arg1, T2 arg2, T3 arg3)
		{
			func(Tuple.Create(arg1, arg2, arg3));
		}
		public static TResult Unapply<T1,T2,T3,T4,TResult>(this Func<Tuple<T1,T2,T3,T4>, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			return func(Tuple.Create(arg1, arg2, arg3, arg4));
		}
		public static void Unapply<T1,T2,T3,T4>(this Action<Tuple<T1,T2,T3,T4>> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			func(Tuple.Create(arg1, arg2, arg3, arg4));
		}
		public static TResult Unapply<T1,T2,T3,T4,T5,TResult>(this Func<Tuple<T1,T2,T3,T4,T5>, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			return func(Tuple.Create(arg1, arg2, arg3, arg4, arg5));
		}
		public static void Unapply<T1,T2,T3,T4,T5>(this Action<Tuple<T1,T2,T3,T4,T5>> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			func(Tuple.Create(arg1, arg2, arg3, arg4, arg5));
		}
		public static TResult Unapply<T1,T2,T3,T4,T5,T6,TResult>(this Func<Tuple<T1,T2,T3,T4,T5,T6>, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			return func(Tuple.Create(arg1, arg2, arg3, arg4, arg5, arg6));
		}
		public static void Unapply<T1,T2,T3,T4,T5,T6>(this Action<Tuple<T1,T2,T3,T4,T5,T6>> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			func(Tuple.Create(arg1, arg2, arg3, arg4, arg5, arg6));
		}
		public static TResult Unapply<T1,T2,T3,T4,T5,T6,T7,TResult>(this Func<Tuple<T1,T2,T3,T4,T5,T6,T7>, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			return func(Tuple.Create(arg1, arg2, arg3, arg4, arg5, arg6, arg7));
		}
		public static void Unapply<T1,T2,T3,T4,T5,T6,T7>(this Action<Tuple<T1,T2,T3,T4,T5,T6,T7>> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			func(Tuple.Create(arg1, arg2, arg3, arg4, arg5, arg6, arg7));
		}
	}
}