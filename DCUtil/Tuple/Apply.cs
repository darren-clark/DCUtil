
namespace DCUtil
{
	using System;

	public static partial class TupleExtensions
	{
		public static TResult Apply<T1,TResult>(this Tuple<T1> args, Func<T1,TResult> func)
		{
			return func(args.Item1);
		}
		public static void Apply<T1>(this Tuple<T1> args, Action<T1> func)
		{
			func(args.Item1);
		}
		public static TResult Apply<T1,T2,TResult>(this Tuple<T1,T2> args, Func<T1,T2,TResult> func)
		{
			return func(args.Item1,args.Item2);
		}
		public static void Apply<T1,T2>(this Tuple<T1,T2> args, Action<T1,T2> func)
		{
			func(args.Item1,args.Item2);
		}
		public static TResult Apply<T1,T2,T3,TResult>(this Tuple<T1,T2,T3> args, Func<T1,T2,T3,TResult> func)
		{
			return func(args.Item1,args.Item2,args.Item3);
		}
		public static void Apply<T1,T2,T3>(this Tuple<T1,T2,T3> args, Action<T1,T2,T3> func)
		{
			func(args.Item1,args.Item2,args.Item3);
		}
		public static TResult Apply<T1,T2,T3,T4,TResult>(this Tuple<T1,T2,T3,T4> args, Func<T1,T2,T3,T4,TResult> func)
		{
			return func(args.Item1,args.Item2,args.Item3,args.Item4);
		}
		public static void Apply<T1,T2,T3,T4>(this Tuple<T1,T2,T3,T4> args, Action<T1,T2,T3,T4> func)
		{
			func(args.Item1,args.Item2,args.Item3,args.Item4);
		}
		public static TResult Apply<T1,T2,T3,T4,T5,TResult>(this Tuple<T1,T2,T3,T4,T5> args, Func<T1,T2,T3,T4,T5,TResult> func)
		{
			return func(args.Item1,args.Item2,args.Item3,args.Item4,args.Item5);
		}
		public static void Apply<T1,T2,T3,T4,T5>(this Tuple<T1,T2,T3,T4,T5> args, Action<T1,T2,T3,T4,T5> func)
		{
			func(args.Item1,args.Item2,args.Item3,args.Item4,args.Item5);
		}
		public static TResult Apply<T1,T2,T3,T4,T5,T6,TResult>(this Tuple<T1,T2,T3,T4,T5,T6> args, Func<T1,T2,T3,T4,T5,T6,TResult> func)
		{
			return func(args.Item1,args.Item2,args.Item3,args.Item4,args.Item5,args.Item6);
		}
		public static void Apply<T1,T2,T3,T4,T5,T6>(this Tuple<T1,T2,T3,T4,T5,T6> args, Action<T1,T2,T3,T4,T5,T6> func)
		{
			func(args.Item1,args.Item2,args.Item3,args.Item4,args.Item5,args.Item6);
		}
		public static TResult Apply<T1,T2,T3,T4,T5,T6,T7,TResult>(this Tuple<T1,T2,T3,T4,T5,T6,T7> args, Func<T1,T2,T3,T4,T5,T6,T7,TResult> func)
		{
			return func(args.Item1,args.Item2,args.Item3,args.Item4,args.Item5,args.Item6,args.Item7);
		}
		public static void Apply<T1,T2,T3,T4,T5,T6,T7>(this Tuple<T1,T2,T3,T4,T5,T6,T7> args, Action<T1,T2,T3,T4,T5,T6,T7> func)
		{
			func(args.Item1,args.Item2,args.Item3,args.Item4,args.Item5,args.Item6,args.Item7);
		}
	}
}
