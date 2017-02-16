
namespace DCUtil.Test.Expression
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using ClassUnderTest = DCUtil.Expression.ExpressionEqualityComparer;

    [TestClass]
    public class ExpressionEqualityComparer
    {

        private IEqualityComparer<Expression> compararer = new ClassUnderTest();

        [TestMethod]
        public void TestSameExpression()
        {
            Expression<Func<int,int,bool>> test = (i,j) => i > 1 && j > 5;
            Expression<Func<int,int,bool>> test2 = (i, j) => i > 1 && j > 5;

            var result = compararer.Equals(test, test2);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestSameWithDifferentNamesExpression()
        {
            Expression<Func<int, int, bool>> test = (i, j) => i > 1 && j > 5;
            Expression<Func<int, int, bool>> test2 = (q, r) => q > 1 && r > 5;

            var result = compararer.Equals(test, test2);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void TestDifferentArgType()
        {
            Expression<Func<int, int, bool>> test = (i, j) => i > 1 && j > 5;
            Expression<Func<int, long, bool>> test2 = (i, j) => i > 1 && j > 5;

            var result = compararer.Equals(test, test2);
            result.Should().BeFalse();
        }

        [TestMethod]
        public void TestDifferentOperator()
        {
            Expression<Func<int, int, bool>> test = (i, j) => i > 1 && j > 5;
            Expression<Func<int, int, bool>> test2 = (i, j) => i < 1 && j > 5;

            var result = compararer.Equals(test, test2);
            result.Should().BeFalse();
        }

        [TestMethod]
        public void TestPartial()
        {
            Expression<Func<int, int, bool>> test = (i, j) => i > 1 && j < 5;
            Expression<Func<int, int, bool>> test2 = (i, j) => i > 1;

            var result = compararer.Equals(test, test2);
            result.Should().BeFalse();
        }

        [TestMethod]
        public void TestPartial2()
        {
            Expression<Func<int, int, bool>> test = (i, j) => i > 1 && j < 5;
            Expression<Func<int, int, bool>> test2 = (i, j) => i > 1;

            var result = compararer.Equals(test2, test);
            result.Should().BeFalse();
        }

        [TestMethod]
        public void TestConstantDifferentConstant()
        {
            Expression<Func<int, int, bool>> test = (i, j) => i > 1;
            Expression<Func<int, int, bool>> test2 = (i, j) => i > 2;

            var result = compararer.Equals(test, test2);
            result.Should().BeFalse();
        }

        private class FieldTestClass
        {
            public int Foo;
            public int Bar;
        }

        [TestMethod]
        public void TestDifferentFields()
        {
            Expression<Func<FieldTestClass, bool>> test = c => c.Foo > 1;
            Expression<Func<FieldTestClass, bool>> test2 = c => c.Bar > 1;

            var result = compararer.Equals(test, test2);
            result.Should().BeFalse();
        }

        private class PropertyTestClass
        {
            public int Foo { get; set; }
            public int Bar { get; set; }
        }

        [TestMethod]
        public void TestDifferentProperties()
        {
            Expression<Func<PropertyTestClass, bool>> test = c => c.Foo > 1;
            Expression<Func<PropertyTestClass, bool>> test2 = c => c.Bar > 1;

            var result = compararer.Equals(test, test2);
            result.Should().BeFalse();
        }
    }
}
