namespace DCUtil
{
    using System;

    public static partial class Function
    {
        public static TResult Apply<T,TResult>(this Func<T, TResult> func, Tuple<T> args)
        {
            return func(args.Item1);
        }

        public static TResult Apply<T1,T2,TResult>(this Func<T1, T2, TResult> func, Tuple<T1,T2> args)
        {
            return func(args.Item1, args.Item2);
        }

        public static TResult Apply<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, Tuple<T1, T2, T3> args)
        {
            return func(args.Item1, args.Item2, args.Item3);
        }

        public static TResult Apply<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func, Tuple<T1, T2, T3, T4> args)
        {
            return func(args.Item1, args.Item2, args.Item3, args.Item4);
        }

        public static TResult Apply<T1, T2, T3, T4, T5, TResult>(this Func<T1, T2, T3, T4, T5, TResult> func, Tuple<T1, T2, T3, T4, T5> args)
        {
            return func(args.Item1, args.Item2, args.Item3, args.Item4, args.Item5);
        }

        public static TResult Apply<T1, T2, T3, T4, T5, T6, TResult>(this Func<T1, T2, T3, T4, T5, T6, TResult> func, Tuple<T1, T2, T3, T4, T5, T6> args)
        {
            return func(args.Item1, args.Item2, args.Item3, args.Item4, args.Item5, args.Item6);
        }

        public static TResult Apply<T1, T2, T3, T4, T5, T6, T7, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TResult> func, Tuple<T1, T2, T3, T4, T5, T6, T7> args)
        {
            return func(args.Item1, args.Item2, args.Item3, args.Item4, args.Item5, args.Item6, args.Item7);
        }
    }
}
