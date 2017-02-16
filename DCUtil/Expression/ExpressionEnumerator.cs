namespace DCUtil.Expression
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class ExpressionEnumerator: IEnumerable<Expression>
    {
        private List<Expression> collection = new List<Expression>();

        public ExpressionEnumerator(Expression expression)
        {
            new CollectingVisitor(collection).Visit(expression);
        }

        public IEnumerator<Expression> GetEnumerator()
        {
            return ((IEnumerable<Expression>)collection).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Expression>)collection).GetEnumerator();
        }

        private class CollectingVisitor: ExpressionVisitor
        {
            private readonly ICollection<Expression> collection;

            public CollectingVisitor(ICollection<Expression> collection)
            {
                this.collection = collection;
            }

            public override Expression Visit(Expression node)
            {
                this.collection.Add(node);
                return base.Visit(node);
            }
        }
    }
}
