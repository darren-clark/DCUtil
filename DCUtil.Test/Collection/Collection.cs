//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using FluentAssertions;
//using System.Collections.Generic;
//using System;
//using System.Linq;

//namespace DCUtil.Test.Collection
//{
//    [TestClass]
//    public class Collection
//    {
//        [TestClass]
//        public class TryGetPosition
//        {
//            [TestMethod]
//            public void TestSinglePredicateFound()
//            {
//                var items = new[] { 1, 2, 3 };

//                var found = items.TryGetPosition(i => i == 3, out var position);
//                found.Should().BeTrue();
//                position.Item1.Should().Be(2);
//            }

//            [TestMethod]
//            public void TestSinglePredicateNotFound()
//            {
//                var items = new[] { 1, 2, 3 };

//                var found = items.TryGetPosition(i => false, out var position);
//                found.Should().BeFalse();
//            }

//            [TestMethod]
//            public void TestSingleItemFound()
//            {
//                var items = new[] { 1, 2, 3 };

//                var found = items.TryGetPosition(3, out var position);
//                found.Should().BeTrue();
//                position.Item1.Should().Be(2);
//            }

//            [TestMethod]
//            public void TestSingleItemNotFound()
//            {
//                var items = new[] { 1, 2, 3 };

//                var found = items.TryGetPosition(4, out var position);
//                found.Should().BeFalse();
//            }

//            private class AlwaysComparer : IEqualityComparer<int>
//            {
//                private bool result;

//                public AlwaysComparer(bool result)
//                {
//                    this.result = result;
//                }

//                bool IEqualityComparer<int>.Equals(int x, int y)
//                {
//                    return this.result;
//                }

//                int IEqualityComparer<int>.GetHashCode(int obj)
//                {
//                    return 0;
//                }
//            }

//            [TestMethod]
//            public void TestSingleItemWithComparerFound()
//            {
//                var comparer = new AlwaysComparer(true);
//                var items = new[] { 1, 2, 3 };

//                var found = items.TryGetPosition(3, comparer, out var position);
//                found.Should().BeTrue();
//                position.Item1.Should().Be(0); // matches 1
//            }

//            [TestMethod]
//            public void TestSingleItemWithComparerNotFound()
//            {
//                var comparer = new AlwaysComparer(false);
//                var items = new[] { 1, 2, 3 };

//                var found = items.TryGetPosition(3, comparer, out var position);
//                found.Should().BeFalse(); // never equal
//            }

//            [TestMethod]
//            public void TestNestedPredicateFound()
//            {
//                var items = new[] {
//                     new int[] { 1, 2, 3 },
//                     new int[] { 4, 5, 6 }
//                };

//                var found = items.TryGetPosition(i => i == 3, out var position);
//                found.Should().BeTrue();
//                position.Item1.Should().Be(0);
//                position.Item2.Should().Be(2);
//            }

//            [TestMethod]
//            public void TestNestedPredicateFoundSecondList()
//            {
//                var items = new[] {
//                     new int[] { 1, 2, 3 },
//                     new int[] { 4, 5, 6 }
//                };

//                var found = items.TryGetPosition(i => i== 4, out var position);
//                found.Should().BeTrue();
//                position.Item1.Should().Be(1);
//                position.Item2.Should().Be(0);
//            }

//            [TestMethod]
//            public void TestNestedPredicateNotFoundSecondList()
//            {
//                var items = new[] {
//                     new int[] { 1, 2, 3 },
//                     new int[] { 4, 5, 6 }
//                };

//                var found = items.TryGetPosition(i => i == 7, out var position);
//                found.Should().BeFalse();
//            }

//        }
//    }
//}
