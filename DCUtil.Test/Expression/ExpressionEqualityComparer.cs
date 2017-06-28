
//namespace DCUtil.Test.Expression
//{
//    using DCUtil.Expression;
//    using FluentAssertions;
//    using Microsoft.VisualStudio.TestTools.UnitTesting;
//    using Moq;
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Linq.Expressions;
//    using ClassUnderTest = DCUtil.Expression.ExpressionEqualityComparer;

//    [TestClass]
//    public class ExpressionEqualityComparer
//    {
//        private IEqualityComparer<Expression> compararer = new ClassUnderTest();

//        [TestClass]
//        public new class Equals :ExpressionEqualityComparer
//        {
//            [TestMethod]
//            public void TestSameExpression()
//            {
//                Expression<Func<int, int, bool>> test = (i, j) => i > 1 && j > 5;
//                Expression<Func<int, int, bool>> test2 = (i, j) => i > 1 && j > 5;

//                var result = compararer.Equals(test, test2);
//                result.Should().BeTrue();
//            }

//            [TestMethod]
//            public void TestSameWithDifferentNamesExpression()
//            {
//                Expression<Func<int, int, bool>> test = (i, j) => i > 1 && j > 5;
//                Expression<Func<int, int, bool>> test2 = (q, r) => q > 1 && r > 5;

//                var result = compararer.Equals(test, test2);
//                result.Should().BeTrue();
//            }

//            [TestMethod]
//            public void TestDifferentArgType()
//            {
//                Expression<Func<int, int, bool>> test = (i, j) => i > 1 && j > 5;
//                Expression<Func<int, long, bool>> test2 = (i, j) => i > 1 && j > 5;

//                var result = compararer.Equals(test, test2);
//                result.Should().BeFalse();
//            }

//            [TestMethod]
//            public void TestDifferentOperator()
//            {
//                Expression<Func<int, int, bool>> test = (i, j) => i > 1 && j > 5;
//                Expression<Func<int, int, bool>> test2 = (i, j) => i < 1 && j > 5;

//                var result = compararer.Equals(test, test2);
//                result.Should().BeFalse();
//            }

//            [TestMethod]
//            public void TestPartial()
//            {
//                Expression<Func<int, int, bool>> test = (i, j) => i > 1 && j < 5;
//                Expression<Func<int, int, bool>> test2 = (i, j) => i > 1;

//                var result = compararer.Equals(test, test2);
//                result.Should().BeFalse();
//            }

//            [TestMethod]
//            public void TestPartial2()
//            {
//                Expression<Func<int, int, bool>> test = (i, j) => i > 1 && j < 5;
//                Expression<Func<int, int, bool>> test2 = (i, j) => i > 1;

//                var result = compararer.Equals(test2, test);
//                result.Should().BeFalse();
//            }

//            [TestMethod]
//            public void TestConstantDifferentConstant()
//            {
//                Expression<Func<int, int, bool>> test = (i, j) => i > 1;
//                Expression<Func<int, int, bool>> test2 = (i, j) => i > 2;

//                var result = compararer.Equals(test, test2);
//                result.Should().BeFalse();
//            }

//            private class FieldTestClass
//            {
//                public int Foo;
//                public int Bar;
//            }

//            [TestMethod]
//            public void TestDifferentFields()
//            {
//                Expression<Func<FieldTestClass, bool>> test = c => c.Foo > 1;
//                Expression<Func<FieldTestClass, bool>> test2 = c => c.Bar > 1;

//                var result = compararer.Equals(test, test2);
//                result.Should().BeFalse();
//            }

//            private class PropertyTestClass
//            {
//                public int Foo { get; set; }
//                public int Bar { get; set; }
//            }

//            [TestMethod]
//            public void TestDifferentProperties()
//            {
//                Expression<Func<PropertyTestClass, bool>> test = c => c.Foo > 1;
//                Expression<Func<PropertyTestClass, bool>> test2 = c => c.Bar > 1;

//                var result = compararer.Equals(test, test2);
//                result.Should().BeFalse();
//            }

//            private interface IFoo
//            {
//                void Bar(int arg1, int arg2);
//                void Baz(int arg1, int arg2);
//            }

//            [TestMethod]
//            public void TestSameMethodCall()
//            {
//                Expression<Action<IFoo>> test = f => f.Bar(1,2);
//                Expression<Action<IFoo>> test2 = f => f.Bar(1,2);

//                var result = compararer.Equals(test, test2);
//                result.Should().BeTrue();
//            }

//            [TestMethod]
//            public void TestDifferentMethodCallOnSameObject()
//            {
//                Expression<Action<IFoo>> test = f => f.Bar(1,2);
//                Expression<Action<IFoo>> test2 = f => f.Baz(1,2);

//                var result = compararer.Equals(test, test2);
//                result.Should().BeFalse();
//            }

//            [TestMethod]
//            public void TestSameMethodCallOnDifferentObject()
//            {
//                Expression<Action<IFoo, IFoo>> test = (a, b) => a.Bar(1, 2);
//                Expression<Action<IFoo, IFoo>> test2 = (a, b) => b.Bar(1, 2);

//                var result = compararer.Equals(test, test2);
//                result.Should().BeFalse();
//            }

//            [TestMethod]
//            public void TestSameMethodCallDifferentParameters()
//            {
//                Expression<Action<IFoo>> test = f => f.Bar(1, 2);
//                Expression<Action<IFoo>> test2 = f => f.Bar(2, 3);

//                var result = compararer.Equals(test, test2);
//                result.Should().BeFalse();
//            }

//            [TestMethod]
//            public void TestSameMethodCallDifferentParameterOrder()
//            {
//                Expression<Action<IFoo>> test = f => f.Bar(1, 2);
//                Expression<Action<IFoo>> test2 = f => f.Bar(2, 1);

//                var result = compararer.Equals(test, test2);
//                result.Should().BeFalse();
//            }

//            [TestMethod]
//            public void TestArray()
//            {
//                Expression<Func<int, int, int[]>> test = (i, j) => new[] { i, j };
//                Expression<Func<int, int, int[]>> test2 = (i, j) => new[] { i, j };

//                var result = compararer.Equals(test, test2);
//                result.Should().BeTrue();
//            }

//            [TestMethod]
//            public void TestArrayOutOfOrder()
//            {
//                Expression<Func<int, int, int[]>> test = (i, j) => new[] { i, j };
//                Expression<Func<int, int, int[]>> test2 = (i, j) => new[] { j, i };

//                var result = compararer.Equals(test, test2);
//                result.Should().BeFalse();
//            }

//            [TestMethod]
//            public void TestArrayAllOutOfOrder()
//            {
//                Expression<Func<int, int, int[]>> test = (i, j) => new[] { i, j };
//                Expression<Func<int, int, int[]>> test2 = (j, i) => new[] { j, i };

//                var result = compararer.Equals(test, test2);
//                result.Should().BeTrue();
//            }

//            [TestMethod]
//            public void TestArrayArgumentOutOfOrder()
//            {
//                Expression<Func<int, int, int[]>> test = (i, j) => new[] { i, j };
//                Expression<Func<int, int, int[]>> test2 = (j, i) => new[] { i, j };

//                var result = compararer.Equals(test, test2);
//                result.Should().BeFalse();
//            }

//            [TestMethod]
//            public void TestConstantArray()
//            {
//                Expression<Func<int[]>> test = () => new[] { 1, 2 };
//                Expression<Func<int[]>> test2 = () => new[] { 1, 2 };

//                var tree = new ExpressionEnumerator(test).ToArray();
//                var result = compararer.Equals(test, test2);
//                result.Should().BeTrue();
//            }
//        }

//        [TestClass]
//        public new class GetHashCode: ExpressionEqualityComparer
//        {
//            [TestMethod]
//            public void TestSameExpression()
//            {
//                Expression<Func<int, int, bool>> test = (i, j) => i > 1 && j > 5;
//                Expression<Func<int, int, bool>> test2 = (i, j) => i > 1 && j > 5;

//                var hash1 = compararer.GetHashCode(test);
//                var hash2 = compararer.GetHashCode(test2);
//                hash1.Should().Be(hash2);
//            }

//            [TestMethod]
//            public void TestSameWithDifferentNamesExpression()
//            {
//                Expression<Func<int, int, bool>> test = (i, j) => i > 1 && j > 5;
//                Expression<Func<int, int, bool>> test2 = (q, r) => q > 1 && r > 5;

//                var hash1 = compararer.GetHashCode(test);
//                var hash2 = compararer.GetHashCode(test2);
//                hash1.Should().Be(hash2);
//            }
//        }
//    }
//}
