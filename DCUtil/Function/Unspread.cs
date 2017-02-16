namespace DCUtil
{
    using System;

    public static partial class Function
    {
        public static Func<T, TResult> Unspread<T,TResult>(this Func<Tuple<T>, TResult> func)
        {
            return func.Unapply;
        }

        public static Func<T1, T2, TResult> Unspread<T1, T2, TResult>(this Func<Tuple<T1, T2>, TResult> func)
        {
            return func.Unapply;
        }

        public static Func<T1, T2, T3, TResult> Unspread<T1, T2, T3, TResult>(this Func<Tuple<T1, T2, T3>, TResult> func)
        {
            return func.Unapply;
        }
    }
}
