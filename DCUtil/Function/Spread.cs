namespace DCUtil
{
    using System;

    public static partial class Function
    {
        public static Func<Tuple<T>,TResult> Spread<T,TResult>(this Func<T,TResult> func)
        {
            return func.Apply;
        }

        public static Func<Tuple<T1,T2>, TResult> Spread<T1, T2, TResult>(this Func<T1, T2, TResult> func)
        {
            return func.Apply;
        }

        public static Func<Tuple<T1, T2, T3>, TResult> Spread<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func)
        {
            return func.Apply;
        }
    }
}
