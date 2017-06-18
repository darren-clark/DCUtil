using System;

namespace DCUtil
{
    public static partial class TupleExtensions
    {
        public static Tuple<T1, T2> Concat<T1,T2>(this Tuple<T1> arg1, Tuple<T2> arg2)
        {
            return Tuple.Create(arg1.Item1, arg2.Item1);
        }

        public static Tuple<T1, T2, T3> Concat<T1, T2, T3>(this Tuple<T1> arg1, Tuple<T2, T3> arg2)
        {
            return Tuple.Create(arg1.Item1, arg2.Item1, arg2.Item2);
        }

        public static Tuple<T1, T2, T3> Concat<T1, T2, T3>(this Tuple<T1, T2> arg1, Tuple<T3> arg2)
        {
            return Tuple.Create(arg1.Item1, arg1.Item2, arg2.Item1);
        }

        public static Tuple<T1, T2, T3> Concat<T1, T2, T3>(this Tuple<T1> arg1, Tuple<T2> arg2, Tuple<T3> arg3)
        {
            return Tuple.Create(arg1.Item1, arg2.Item1, arg3.Item1);
        }

        public static Tuple<T1, T2, T3, T4> Concat<T1, T2, T3, T4>(this Tuple<T1> arg1, Tuple<T2, T3, T4> arg2)
        {
            return Tuple.Create(arg1.Item1, arg2.Item1, arg2.Item2, arg2.Item3);
        }

        public static Tuple<T1, T2, T3, T4> Concat<T1, T2, T3, T4>(this Tuple<T1> arg1, Tuple<T2> arg2, Tuple<T3, T4> arg3)
        {
            return Tuple.Create(arg1.Item1, arg2.Item1, arg3.Item1, arg3.Item2);
        }

        public static Tuple<T1, T2, T3, T4> Concat<T1, T2, T3, T4>(this Tuple<T1> arg1, Tuple<T2> arg2, Tuple<T3> arg3, Tuple<T4> arg4)
        {
            return Tuple.Create(arg1.Item1, arg2.Item1, arg3.Item1, arg4.Item1);
        }

        public static Tuple<T1, T2, T3, T4> Concat<T1, T2, T3, T4>(this Tuple<T1> arg1, Tuple<T2, T3> arg2, Tuple<T4> arg3)
        {
            return Tuple.Create(arg1.Item1, arg2.Item1, arg2.Item2, arg3.Item1);
        }

        public static Tuple<T1, T2, T3, T4> Concat<T1,T2,T3,T4>(this Tuple<T1, T2> arg1, Tuple<T3, T4> arg2)
        {
            return Tuple.Create(arg1.Item1, arg1.Item2, arg2.Item1, arg2.Item2);
        }

        public static Tuple<T1, T2, T3, T4> Concat<T1, T2, T3, T4>(this Tuple<T1, T2> arg1, Tuple<T3> arg2, Tuple<T4> arg3)
        {
            return Tuple.Create(arg1.Item1, arg1.Item2, arg2.Item1, arg3.Item1);
        }

        public static Tuple<T1, T2, T3, T4> Concat<T1, T2, T3, T4>(this Tuple<T1, T2, T3> arg1, Tuple<T4> arg2)
        {
            return Tuple.Create(arg1.Item1, arg1.Item2, arg1.Item3, arg2.Item1);
        }
    }
}
