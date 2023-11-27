using HotChocolate.Data.Sorting;

namespace HotChocolateAspDotNetCore.Configuration;

public class OrderByClauseSortInputType : SortInputType
{
    protected override void Configure(ISortInputTypeDescriptor descriptor)
    {
        descriptor.Name("OrderByClause");
        descriptor.Field("direction").Type<DefaultSortEnumType>();
        descriptor.Field("nulls").Type<NullsOrderSortEnumType>();
    }
}