
namespace DCUtil
{
	using System;

	public static partial class FunctionExtensions
	{
		public static Func<T1,TResult> Unspread<T1,TResult>(this Func<Tuple<T1>, TResult> func)
		{
			return func.Unapply;
		}
		public static Action<T1> Unspread<T1>(this Action<Tuple<T1>> func)
		{
			return func.Unapply;
		}
		public static Func<T1,T2,TResult> Unspread<T1,T2,TResult>(this Func<Tuple<T1,T2>, TResult> func)
		{
			return func.Unapply;
		}
		public static Action<T1,T2> Unspread<T1,T2>(this Action<Tuple<T1,T2>> func)
		{
			return func.Unapply;
		}
		public static Func<T1,T2,T3,TResult> Unspread<T1,T2,T3,TResult>(this Func<Tuple<T1,T2,T3>, TResult> func)
		{
			return func.Unapply;
		}
		public static Action<T1,T2,T3> Unspread<T1,T2,T3>(this Action<Tuple<T1,T2,T3>> func)
		{
			return func.Unapply;
		}
		public static Func<T1,T2,T3,T4,TResult> Unspread<T1,T2,T3,T4,TResult>(this Func<Tuple<T1,T2,T3,T4>, TResult> func)
		{
			return func.Unapply;
		}
		public static Action<T1,T2,T3,T4> Unspread<T1,T2,T3,T4>(this Action<Tuple<T1,T2,T3,T4>> func)
		{
			return func.Unapply;
		}
		public static Func<T1,T2,T3,T4,T5,TResult> Unspread<T1,T2,T3,T4,T5,TResult>(this Func<Tuple<T1,T2,T3,T4,T5>, TResult> func)
		{
			return func.Unapply;
		}
		public static Action<T1,T2,T3,T4,T5> Unspread<T1,T2,T3,T4,T5>(this Action<Tuple<T1,T2,T3,T4,T5>> func)
		{
			return func.Unapply;
		}
		public static Func<T1,T2,T3,T4,T5,T6,TResult> Unspread<T1,T2,T3,T4,T5,T6,TResult>(this Func<Tuple<T1,T2,T3,T4,T5,T6>, TResult> func)
		{
			return func.Unapply;
		}
		public static Action<T1,T2,T3,T4,T5,T6> Unspread<T1,T2,T3,T4,T5,T6>(this Action<Tuple<T1,T2,T3,T4,T5,T6>> func)
		{
			return func.Unapply;
		}
		public static Func<T1,T2,T3,T4,T5,T6,T7,TResult> Unspread<T1,T2,T3,T4,T5,T6,T7,TResult>(this Func<Tuple<T1,T2,T3,T4,T5,T6,T7>, TResult> func)
		{
			return func.Unapply;
		}
		public static Action<T1,T2,T3,T4,T5,T6,T7> Unspread<T1,T2,T3,T4,T5,T6,T7>(this Action<Tuple<T1,T2,T3,T4,T5,T6,T7>> func)
		{
			return func.Unapply;
		}
	}
}