namespace DCUtil
{
    using System;

    public static partial class FunctionExtensions
    {
        public static Func<TResult> PartialRight<T,TResult>(this Func<T,TResult> func, T arg1)
        {
            return () => func(arg1);
        }

        public static Func<T1,TResult> PartialRight<T1, T2, TResult>(this Func<T1,T2,TResult> func, T2 arg2)
        {
            return (arg1) => func(arg1, arg2);
        }

        public static Func<TResult> PartialRight<T1, T2, TResult>(this Func<T1, T2, TResult> func, T1 arg1, T2 arg2)
        {
            return () => func(arg1, arg2);
        }

        public static Func<T1, T2, TResult> PartialRight<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T3 arg3)
        {
            return (arg1, arg2) => func(arg1, arg2, arg3);
        }

        public static Func<TResult> PartialRight<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T3 arg3, T2 arg2, T1 arg1)
        {
            return () => func(arg1, arg2, arg3);
        }

        public static Func<T1, TResult> PartialRight<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T3 arg3, T2 arg2)
        {
            return arg1 => func(arg1, arg2, arg3);
        }
    }
}
