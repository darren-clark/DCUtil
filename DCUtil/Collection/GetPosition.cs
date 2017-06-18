using System;
using System.Collections.Generic;

namespace DCUtil
{
    public static class CollectionExtensions
    {
        public static bool TryGetPosition<T>(this IEnumerable<T> collection, Func<T,bool> predicate, out Tuple<int> position)
        {
            int i = 0;
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    position = new Tuple<int>(i);
                    return true;
                }
                i++;
            }
            position = default(Tuple<int>);
            return false;
        }

        public static bool TryGetPosition<T>(this IEnumerable<T> collection, T search, IEqualityComparer<T> comparer, out Tuple<int> position)
        {
            return TryGetPosition(collection, t => comparer.Equals(t, search), out position);
        }

        public static bool TryGetPosition<T>(this IEnumerable<T> collection, T search, out Tuple<int> position)
        {
            return TryGetPosition(collection, search, EqualityComparer<T>.Default, out position);
        }

        public static Tuple<int> GetPosition<T>(this IEnumerable<T> collection, Func<T,bool> predicate)
        {
            if(TryGetPosition(collection, predicate, out var position))
            {
                return position;
            }

            throw new KeyNotFoundException();
        }

        public static Tuple<int> GetPosition<T>(this IEnumerable<T> collection, T search, IEqualityComparer<T> comparer)
        {
            return GetPosition(collection, t => comparer.Equals(t, search));
        }

        public static Tuple<int> GetPosition<T>(this IEnumerable<T> collection, T search)
        {
            return GetPosition(collection, search, EqualityComparer<T>.Default);
        }

        public static bool TryGetPosition<T>(this IEnumerable<IEnumerable<T>> collections, Func<T,bool> predicate, out Tuple<int, int> position)
        {
            Tuple<int> inner = default(Tuple<int>);

            if (collections.TryGetPosition(c => c.TryGetPosition(predicate, out inner), out Tuple<int> outer))
            {
                position =  outer.Concat(inner);
                return true;
            }

            position = default(Tuple<int, int>);
            return false;
        }

        public static Tuple<int, int> GetPosition<T>(this IEnumerable<IEnumerable<T>> collection, Func<T, bool> predicate)
        {
            if (TryGetPosition(collection, predicate, out var position))
            {
                return position;
            }

            throw new KeyNotFoundException();
        }

        public static Tuple<int, int> GetPosition<T>(this IEnumerable<IEnumerable<T>> collection, T search, IEqualityComparer<T> comparer)
        {
            return GetPosition(collection, t => comparer.Equals(t, search));
        }

        public static Tuple<int, int> GetPosition<T>(this IEnumerable<IEnumerable<T>> collection, T search)
        {
            return GetPosition(collection, search, EqualityComparer<T>.Default);
        }

        public static bool TryGetPosition<T>(this IEnumerable<IEnumerable<IEnumerable<T>>> collection, Func<T, bool> predicate, out Tuple<int,int,int> position)
        {
            Tuple<int, int> inner = default(Tuple<int, int>);

            if (TryGetPosition(collection, c => c.TryGetPosition(predicate, out inner), out Tuple<int> outer))
            {
                position = outer.Concat(inner);
                return true;
            }

            position = default(Tuple<int, int, int>);
            return false;
        }

        public static bool TryGetPosition<T>(this IEnumerable<IEnumerable<IEnumerable<IEnumerable<T>>>> collection, Func<T, bool> predicate, out Tuple<int, int, int, int> position)
        {
            Tuple<int, int, int> inner = default(Tuple<int, int, int>);

            if (TryGetPosition(collection, c => c.TryGetPosition(predicate, out inner), out Tuple<int> outer))
            {
                position = outer.Concat(inner);
                return true;
            }

            position = default(Tuple<int, int, int, int>);
            return false;
        }
    }
}
