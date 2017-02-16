namespace DCUtil
{
    using System;

    public static partial class Function
    {
        public static TResult Unapply<T,TResult>(this Func<Tuple<T>, TResult> func, T arg)
        {
            return func(Tuple.Create(arg));
        }

        public static TResult Unapply<T1, T2, TResult>(this Func<Tuple<T1, T2>, TResult> func, T1 arg1, T2 arg2)
        {
            return func(Tuple.Create(arg1,arg2));
        }

        public static TResult Unapply<T1, T2, T3, TResult>(this Func<Tuple<T1, T2, T3>, TResult> func, T1 arg1, T2 arg2, T3 arg3)
        {
            return func(Tuple.Create(arg1, arg2, arg3));
        }

        public static TResult Unapply<T1, T2, T3, T4, TResult>(this Func<Tuple<T1, T2, T3, T4>, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            return func(Tuple.Create(arg1, arg2, arg3, arg4));
        }

        public static TResult Unapply<T1, T2, T3, T4, T5, TResult>(this Func<Tuple<T1, T2, T3, T4, T5>, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            return func(Tuple.Create(arg1, arg2, arg3, arg4,arg5));
        }
    }
}
