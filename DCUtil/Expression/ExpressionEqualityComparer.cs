
namespace DCUtil.Expression
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class ExpressionEqualityComparer : IEqualityComparer<Expression>
    {
        bool IEqualityComparer<Expression>.Equals(Expression x, Expression y)
        {
            if (x == null || y == null) return x == y;

            var visitor = new ComparingVisitor(new ExpressionEnumerator(x));
            return visitor.Compare(y);
        }

        int IEqualityComparer<Expression>.GetHashCode(Expression obj)
        {
            //TODO: Write decent hash function based on node type.
            return 0;
        }

        private class ComparingVisitor: ExpressionVisitor
        {
            private IEnumerable<Expression> expected;
            private IEnumerator<Expression> enumerator;
            private bool areEqual;

            public ComparingVisitor(IEnumerable<Expression> expected)
            {
                this.expected = expected;
            }

            public bool Compare(Expression expression)
            {
                this.enumerator = expected.GetEnumerator();
                try
                {
                    this.areEqual = true;
                    Visit(expression);
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
                return Test(node, (LambdaExpression e) => e.Type == typeof(T) && e.Name == e.Name, base.VisitLambda<T>);
            }

            protected override Expression VisitConstant(ConstantExpression node)
            {
                if (node.Value is IEnumerable)
                {
                    throw new NotImplementedException();
                }
                return Test(node, (ConstantExpression e) => e.Value.Equals(node.Value), base.VisitConstant);
            }

            protected override Expression VisitMember(MemberExpression node)
            {
                return Test(node, (MemberExpression e) => e.Member.Equals(node.Member), base.VisitMember);
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
