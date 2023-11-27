using HotChocolate.Data.Sorting.Expressions;
using HotChocolate.Data.Sorting;
using System.Linq.Expressions;

namespace HotChocolateAspDotNetCore.Handlers;

public class NullsLastSortOperationHandler : QueryableOperationHandlerBase
{
    public NullsLastSortOperationHandler() : base(3)
    {
    }

    protected override QueryableSortOperation HandleOperation(
        QueryableSortContext context,
        QueryableFieldSelector fieldSelector,
        ISortField field,
        ISortEnumValue? sortEnumValue)
    {
        return DescendingSortOperation.From(fieldSelector);
    }

    private sealed class DescendingSortOperation : QueryableSortOperation
    {
        private DescendingSortOperation(QueryableFieldSelector fieldSelector)
            : base(fieldSelector)
        {
        }

        public override Expression CompileOrderBy(Expression expression)
        {
            return Expression.Call(
                expression.GetEnumerableKind(),
                nameof(Queryable.OrderByDescending),
                new[] { ParameterExpression.Type, Selector.Type },
                expression,
                Expression.Lambda(Selector, ParameterExpression));
        }

        public override Expression CompileThenBy(Expression expression)
        {
            return Expression.Call(
                expression.GetEnumerableKind(),
                nameof(Queryable.ThenByDescending),
                new[] { ParameterExpression.Type, Selector.Type },
                expression,
                Expression.Lambda(Selector, ParameterExpression));
        }

        public static DescendingSortOperation From(QueryableFieldSelector selector) =>
            new DescendingSortOperation(selector);
    }
}