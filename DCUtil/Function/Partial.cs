
namespace DCUtil
{
	using System;

	public static partial class FunctionExtensions
	{
		public static Func<TResult> Partial<T1,TResult>(this Func<T1,TResult> func, T1 arg1)
		{
			return () => func(arg1);
		}
		public static Action Partial<T1>(this Action<T1> func, T1 arg1)
		{
			return () => func(arg1);
		}
		public static Func<T2,TResult> Partial<T1,T2,TResult>(this Func<T1,T2,TResult> func, T1 arg1)
		{
			return (arg2) => func(arg1, arg2);
		}
		public static Action<T2> Partial<T1,T2>(this Action<T1,T2> func, T1 arg1)
		{
			return (arg2) => func(arg1, arg2);
		}
		public static Func<TResult> Partial<T1,T2,TResult>(this Func<T1,T2,TResult> func, T1 arg1, T2 arg2)
		{
			return () => func(arg1, arg2);
		}
		public static Action Partial<T1,T2>(this Action<T1,T2> func, T1 arg1, T2 arg2)
		{
			return () => func(arg1, arg2);
		}
		public static Func<T2,T3,TResult> Partial<T1,T2,T3,TResult>(this Func<T1,T2,T3,TResult> func, T1 arg1)
		{
			return (arg2, arg3) => func(arg1, arg2, arg3);
		}
		public static Action<T2,T3> Partial<T1,T2,T3>(this Action<T1,T2,T3> func, T1 arg1)
		{
			return (arg2, arg3) => func(arg1, arg2, arg3);
		}
		public static Func<T3,TResult> Partial<T1,T2,T3,TResult>(this Func<T1,T2,T3,TResult> func, T1 arg1, T2 arg2)
		{
			return (arg3) => func(arg1, arg2, arg3);
		}
		public static Action<T3> Partial<T1,T2,T3>(this Action<T1,T2,T3> func, T1 arg1, T2 arg2)
		{
			return (arg3) => func(arg1, arg2, arg3);
		}
		public static Func<TResult> Partial<T1,T2,T3,TResult>(this Func<T1,T2,T3,TResult> func, T1 arg1, T2 arg2, T3 arg3)
		{
			return () => func(arg1, arg2, arg3);
		}
		public static Action Partial<T1,T2,T3>(this Action<T1,T2,T3> func, T1 arg1, T2 arg2, T3 arg3)
		{
			return () => func(arg1, arg2, arg3);
		}
		public static Func<T2,T3,T4,TResult> Partial<T1,T2,T3,T4,TResult>(this Func<T1,T2,T3,T4,TResult> func, T1 arg1)
		{
			return (arg2, arg3, arg4) => func(arg1, arg2, arg3, arg4);
		}
		public static Action<T2,T3,T4> Partial<T1,T2,T3,T4>(this Action<T1,T2,T3,T4> func, T1 arg1)
		{
			return (arg2, arg3, arg4) => func(arg1, arg2, arg3, arg4);
		}
		public static Func<T3,T4,TResult> Partial<T1,T2,T3,T4,TResult>(this Func<T1,T2,T3,T4,TResult> func, T1 arg1, T2 arg2)
		{
			return (arg3, arg4) => func(arg1, arg2, arg3, arg4);
		}
		public static Action<T3,T4> Partial<T1,T2,T3,T4>(this Action<T1,T2,T3,T4> func, T1 arg1, T2 arg2)
		{
			return (arg3, arg4) => func(arg1, arg2, arg3, arg4);
		}
		public static Func<T4,TResult> Partial<T1,T2,T3,T4,TResult>(this Func<T1,T2,T3,T4,TResult> func, T1 arg1, T2 arg2, T3 arg3)
		{
			return (arg4) => func(arg1, arg2, arg3, arg4);
		}
		public static Action<T4> Partial<T1,T2,T3,T4>(this Action<T1,T2,T3,T4> func, T1 arg1, T2 arg2, T3 arg3)
		{
			return (arg4) => func(arg1, arg2, arg3, arg4);
		}
		public static Func<TResult> Partial<T1,T2,T3,T4,TResult>(this Func<T1,T2,T3,T4,TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			return () => func(arg1, arg2, arg3, arg4);
		}
		public static Action Partial<T1,T2,T3,T4>(this Action<T1,T2,T3,T4> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			return () => func(arg1, arg2, arg3, arg4);
		}
		public static Func<T2,T3,T4,T5,TResult> Partial<T1,T2,T3,T4,T5,TResult>(this Func<T1,T2,T3,T4,T5,TResult> func, T1 arg1)
		{
			return (arg2, arg3, arg4, arg5) => func(arg1, arg2, arg3, arg4, arg5);
		}
		public static Action<T2,T3,T4,T5> Partial<T1,T2,T3,T4,T5>(this Action<T1,T2,T3,T4,T5> func, T1 arg1)
		{
			return (arg2, arg3, arg4, arg5) => func(arg1, arg2, arg3, arg4, arg5);
		}
		public static Func<T3,T4,T5,TResult> Partial<T1,T2,T3,T4,T5,TResult>(this Func<T1,T2,T3,T4,T5,TResult> func, T1 arg1, T2 arg2)
		{
			return (arg3, arg4, arg5) => func(arg1, arg2, arg3, arg4, arg5);
		}
		public static Action<T3,T4,T5> Partial<T1,T2,T3,T4,T5>(this Action<T1,T2,T3,T4,T5> func, T1 arg1, T2 arg2)
		{
			return (arg3, arg4, arg5) => func(arg1, arg2, arg3, arg4, arg5);
		}
		public static Func<T4,T5,TResult> Partial<T1,T2,T3,T4,T5,TResult>(this Func<T1,T2,T3,T4,T5,TResult> func, T1 arg1, T2 arg2, T3 arg3)
		{
			return (arg4, arg5) => func(arg1, arg2, arg3, arg4, arg5);
		}
		public static Action<T4,T5> Partial<T1,T2,T3,T4,T5>(this Action<T1,T2,T3,T4,T5> func, T1 arg1, T2 arg2, T3 arg3)
		{
			return (arg4, arg5) => func(arg1, arg2, arg3, arg4, arg5);
		}
		public static Func<T5,TResult> Partial<T1,T2,T3,T4,T5,TResult>(this Func<T1,T2,T3,T4,T5,TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			return (arg5) => func(arg1, arg2, arg3, arg4, arg5);
		}
		public static Action<T5> Partial<T1,T2,T3,T4,T5>(this Action<T1,T2,T3,T4,T5> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			return (arg5) => func(arg1, arg2, arg3, arg4, arg5);
		}
		public static Func<TResult> Partial<T1,T2,T3,T4,T5,TResult>(this Func<T1,T2,T3,T4,T5,TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			return () => func(arg1, arg2, arg3, arg4, arg5);
		}
		public static Action Partial<T1,T2,T3,T4,T5>(this Action<T1,T2,T3,T4,T5> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			return () => func(arg1, arg2, arg3, arg4, arg5);
		}
		public static Func<T2,T3,T4,T5,T6,TResult> Partial<T1,T2,T3,T4,T5,T6,TResult>(this Func<T1,T2,T3,T4,T5,T6,TResult> func, T1 arg1)
		{
			return (arg2, arg3, arg4, arg5, arg6) => func(arg1, arg2, arg3, arg4, arg5, arg6);
		}
		public static Action<T2,T3,T4,T5,T6> Partial<T1,T2,T3,T4,T5,T6>(this Action<T1,T2,T3,T4,T5,T6> func, T1 arg1)
		{
			return (arg2, arg3, arg4, arg5, arg6) => func(arg1, arg2, arg3, arg4, arg5, arg6);
		}
		public static Func<T3,T4,T5,T6,TResult> Partial<T1,T2,T3,T4,T5,T6,TResult>(this Func<T1,T2,T3,T4,T5,T6,TResult> func, T1 arg1, T2 arg2)
		{
			return (arg3, arg4, arg5, arg6) => func(arg1, arg2, arg3, arg4, arg5, arg6);
		}
		public static Action<T3,T4,T5,T6> Partial<T1,T2,T3,T4,T5,T6>(this Action<T1,T2,T3,T4,T5,T6> func, T1 arg1, T2 arg2)
		{
			return (arg3, arg4, arg5, arg6) => func(arg1, arg2, arg3, arg4, arg5, arg6);
		}
		public static Func<T4,T5,T6,TResult> Partial<T1,T2,T3,T4,T5,T6,TResult>(this Func<T1,T2,T3,T4,T5,T6,TResult> func, T1 arg1, T2 arg2, T3 arg3)
		{
			return (arg4, arg5, arg6) => func(arg1, arg2, arg3, arg4, arg5, arg6);
		}
		public static Action<T4,T5,T6> Partial<T1,T2,T3,T4,T5,T6>(this Action<T1,T2,T3,T4,T5,T6> func, T1 arg1, T2 arg2, T3 arg3)
		{
			return (arg4, arg5, arg6) => func(arg1, arg2, arg3, arg4, arg5, arg6);
		}
		public static Func<T5,T6,TResult> Partial<T1,T2,T3,T4,T5,T6,TResult>(this Func<T1,T2,T3,T4,T5,T6,TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			return (arg5, arg6) => func(arg1, arg2, arg3, arg4, arg5, arg6);
		}
		public static Action<T5,T6> Partial<T1,T2,T3,T4,T5,T6>(this Action<T1,T2,T3,T4,T5,T6> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			return (arg5, arg6) => func(arg1, arg2, arg3, arg4, arg5, arg6);
		}
		public static Func<T6,TResult> Partial<T1,T2,T3,T4,T5,T6,TResult>(this Func<T1,T2,T3,T4,T5,T6,TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			return (arg6) => func(arg1, arg2, arg3, arg4, arg5, arg6);
		}
		public static Action<T6> Partial<T1,T2,T3,T4,T5,T6>(this Action<T1,T2,T3,T4,T5,T6> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			return (arg6) => func(arg1, arg2, arg3, arg4, arg5, arg6);
		}
		public static Func<TResult> Partial<T1,T2,T3,T4,T5,T6,TResult>(this Func<T1,T2,T3,T4,T5,T6,TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			return () => func(arg1, arg2, arg3, arg4, arg5, arg6);
		}
		public static Action Partial<T1,T2,T3,T4,T5,T6>(this Action<T1,T2,T3,T4,T5,T6> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			return () => func(arg1, arg2, arg3, arg4, arg5, arg6);
		}
		public static Func<T2,T3,T4,T5,T6,T7,TResult> Partial<T1,T2,T3,T4,T5,T6,T7,TResult>(this Func<T1,T2,T3,T4,T5,T6,T7,TResult> func, T1 arg1)
		{
			return (arg2, arg3, arg4, arg5, arg6, arg7) => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}
		public static Action<T2,T3,T4,T5,T6,T7> Partial<T1,T2,T3,T4,T5,T6,T7>(this Action<T1,T2,T3,T4,T5,T6,T7> func, T1 arg1)
		{
			return (arg2, arg3, arg4, arg5, arg6, arg7) => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}
		public static Func<T3,T4,T5,T6,T7,TResult> Partial<T1,T2,T3,T4,T5,T6,T7,TResult>(this Func<T1,T2,T3,T4,T5,T6,T7,TResult> func, T1 arg1, T2 arg2)
		{
			return (arg3, arg4, arg5, arg6, arg7) => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}
		public static Action<T3,T4,T5,T6,T7> Partial<T1,T2,T3,T4,T5,T6,T7>(this Action<T1,T2,T3,T4,T5,T6,T7> func, T1 arg1, T2 arg2)
		{
			return (arg3, arg4, arg5, arg6, arg7) => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}
		public static Func<T4,T5,T6,T7,TResult> Partial<T1,T2,T3,T4,T5,T6,T7,TResult>(this Func<T1,T2,T3,T4,T5,T6,T7,TResult> func, T1 arg1, T2 arg2, T3 arg3)
		{
			return (arg4, arg5, arg6, arg7) => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}
		public static Action<T4,T5,T6,T7> Partial<T1,T2,T3,T4,T5,T6,T7>(this Action<T1,T2,T3,T4,T5,T6,T7> func, T1 arg1, T2 arg2, T3 arg3)
		{
			return (arg4, arg5, arg6, arg7) => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}
		public static Func<T5,T6,T7,TResult> Partial<T1,T2,T3,T4,T5,T6,T7,TResult>(this Func<T1,T2,T3,T4,T5,T6,T7,TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			return (arg5, arg6, arg7) => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}
		public static Action<T5,T6,T7> Partial<T1,T2,T3,T4,T5,T6,T7>(this Action<T1,T2,T3,T4,T5,T6,T7> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			return (arg5, arg6, arg7) => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}
		public static Func<T6,T7,TResult> Partial<T1,T2,T3,T4,T5,T6,T7,TResult>(this Func<T1,T2,T3,T4,T5,T6,T7,TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			return (arg6, arg7) => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}
		public static Action<T6,T7> Partial<T1,T2,T3,T4,T5,T6,T7>(this Action<T1,T2,T3,T4,T5,T6,T7> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			return (arg6, arg7) => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}
		public static Func<T7,TResult> Partial<T1,T2,T3,T4,T5,T6,T7,TResult>(this Func<T1,T2,T3,T4,T5,T6,T7,TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			return (arg7) => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}
		public static Action<T7> Partial<T1,T2,T3,T4,T5,T6,T7>(this Action<T1,T2,T3,T4,T5,T6,T7> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			return (arg7) => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}
		public static Func<TResult> Partial<T1,T2,T3,T4,T5,T6,T7,TResult>(this Func<T1,T2,T3,T4,T5,T6,T7,TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			return () => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}
		public static Action Partial<T1,T2,T3,T4,T5,T6,T7>(this Action<T1,T2,T3,T4,T5,T6,T7> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			return () => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}
	}
}