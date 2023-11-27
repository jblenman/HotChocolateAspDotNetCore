using HotChocolate.Data.Sorting;

namespace HotChocolateAspDotNetCore.Configuration;

public class NullsOrderSortEnumType : SortEnumType
{
    protected override void Configure(ISortEnumTypeDescriptor descriptor)
    {
        descriptor.Name("NullsOrder");
        descriptor.Operation(2).Name("NULLS_FIRST");
        descriptor.Operation(3).Name("NULLS_LAST");
    }
}