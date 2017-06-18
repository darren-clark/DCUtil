
namespace DCUtil.Expression
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Linq.Expressions;

    public class ExpressionEqualityComparer : IEqualityComparer<Expression>
    {
        public static readonly IEqualityComparer<Expression> Comparer = new ExpressionEqualityComparer();

        bool IEqualityComparer<Expression>.Equals(Expression x, Expression y)
        {
            if (x == null || y == null) return x == y;

            var visitor = new ComparingVisitor(x);
            return visitor.Compare(y);
        }

        int IEqualityComparer<Expression>.GetHashCode(Expression obj)
        {
            return new HashingVisitor().Hash(obj);
        }

        private class HashingVisitor : ExpressionVisitor
        {
            private int hash;

            public int Hash(Expression expression)
            {
                unchecked
                {
                    hash = 0;
                    Visit(expression);
                    return hash;
                }
            }

            public override Expression Visit(Expression node)
            {
                unchecked
                {
                    hash = 13 * hash + (byte)node.NodeType;
                }

                return base.Visit(node);
            }
        }

        private class ComparingVisitor: ExpressionVisitor
        {
            private IEnumerable<Expression> expected;
            private Stack<ReadOnlyCollection<ParameterExpression>> parameters = new Stack<ReadOnlyCollection<ParameterExpression>>();
            private Stack<ReadOnlyCollection<ParameterExpression>> expectedParameters = new Stack<ReadOnlyCollection<ParameterExpression>>();

            private IEnumerator<Expression> enumerator;
            private bool areEqual;


            public ComparingVisitor(Expression expected)
            {
                this.expected = new ExpressionEnumerator(expected);
                switch(expected.NodeType)
                {
                    case ExpressionType.Lambda:
                        this.expectedParameters.Push(((LambdaExpression)expected).Parameters);
                        break;
                    case ExpressionType.Block:
                        this.expectedParameters.Push(((BlockExpression)expected).Variables);
                        break;
                }
            }

            public bool Compare(Expression expression)
            {
                switch (expression.NodeType)
                {
                    case ExpressionType.Lambda:
                        this.parameters.Push(((LambdaExpression)expression).Parameters);
                        break;
                    case ExpressionType.Block:
                        this.parameters.Push(((BlockExpression)expression).Variables);
                        break;
                }

                this.enumerator = expected.GetEnumerator();
                try
                {
                    this.areEqual = true;
                    this.Visit(expression);
                    if (enumerator.MoveNext())
                        areEqual = false;
                }
                finally
                {
                    this.enumerator.Dispose();
                }
                
                return areEqual;
            }

            public override Expression Visit(Expression node)
            {
                if (!areEqual) return node;

                if (!enumerator.MoveNext())
                {
                    areEqual = false;
                    return node;
                }

                return Test(node, (Expression e) => e.NodeType == node.NodeType, base.Visit);
            }

            protected override Expression VisitLambda<T>(Expression<T> node)
            {
                return Test(node, (LambdaExpression e) => e.Type == typeof(T) && e.Name == node.Name, base.VisitLambda<T>);
            }

            protected override Expression VisitBlock(BlockExpression node)
            {
                throw new NotImplementedException();
            }

            protected override Expression VisitConstant(ConstantExpression node)
            {
                return Test(node, (ConstantExpression e) => e.Value.Equals(node.Value), base.VisitConstant);
            }

            protected override Expression VisitMember(MemberExpression node)
            {
                return Test(node, (MemberExpression e) => e.Member.Equals(node.Member), base.VisitMember);
            }

            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                return Test(node, (MethodCallExpression e) => e.Method.Equals(node.Method), base.VisitMethodCall);
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                // Compare parameters by position
                return Test(node, (ParameterExpression e) => expectedParameters.GetPosition(e).Equals(parameters.GetPosition(node)), base.VisitParameter);
            }

            private Expression Test<TIn, TTest>(TIn node, Func<TTest, bool> test, Func<TIn,Expression> success) where TIn:Expression where TTest: Expression
            {
                if (test((TTest) this.enumerator.Current))
                {
                    return success(node);
                }
                else
                {
                    areEqual = false;
                    return node;
                }
            }
        }
    }
}
