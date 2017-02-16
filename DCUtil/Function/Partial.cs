namespace DCUtil
{
    using System;

    public static partial class Function
    {
        public static Func<TResult> Partial<T,TResult>(this Func<T,TResult> func, T arg)
        {
            return () => func(arg);
        }

        public static Func<TResult> Partial<T1, T2, TResult>(this Func<T1, T2, TResult> func, T1 arg1, T2 arg2)
        {
            return () => func(arg1, arg2);
        }

        public static Func<T2,TResult> Partial<T1, T2, TResult>(this Func<T1, T2, TResult> func, T1 arg1)
        {
            return arg2 => func(arg1,arg2);
        }

        public static Func<TResult> Partial<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T1 arg1, T2 arg2, T3 arg3)
        {
            return () => func(arg1, arg2, arg3);
        }

        public static Func<T3, TResult> Partial<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T1 arg1, T2 arg2)
        {
            return arg3 => func(arg1, arg2, arg3);
        }

        public static Func<T2, T3, TResult> Partial<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T1 arg1)
        {
            return (arg2, arg3) => func(arg1, arg2, arg3);
        }

        public static Func<TResult> Partial<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            return () => func(arg1, arg2, arg3, arg4);
        }

        public static Func<T4, TResult> Partial<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func, T1 arg1, T2 arg2, T3 arg3)
        {
            return arg4 => func(arg1, arg2, arg3, arg4);
        }

        public static Func<T3, T4, TResult> Partial<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func, T1 arg1, T2 arg2)
        {
            return (arg3, arg4) => func(arg1, arg2, arg3, arg4);
        }

        public static Func<T2, T3, T4, TResult> Partial<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func, T1 arg1)
        {
            return (arg2, arg3, arg4) => func(arg1, arg2, arg3, arg4);
        }
    }
}
