using HotChocolate.Data.Sorting;

namespace HotChocolateAspDotNetCore.Configuration;

public class DirectionSortEnumType : DefaultSortEnumType
{
    protected override void Configure(ISortEnumTypeDescriptor descriptor)
    {
        descriptor.Name("Direction");
        descriptor.Operation(DefaultSortOperations.Ascending);
        descriptor.Operation(DefaultSortOperations.Descending);
    }
}