using HotChocolate.Data.Sorting;
using HotChocolate.Data.Sorting.Expressions;
using HotChocolateAspDotNetCore.Handlers;
using HotChocolateAspDotNetCore.ObjectTypes;

namespace HotChocolateAspDotNetCore.Configuration;

public class CustomSortConvention : SortConvention
{
    protected override void Configure(ISortConventionDescriptor descriptor)
    {
        descriptor.AddDefaults();
        descriptor.ArgumentName("orderBy");
        descriptor.AddDefaultOperations();
        descriptor.Operation(2).Name("NULLS_FIRST");
        descriptor.Operation(3).Name("NULLS_LAST");
        descriptor.Provider(
            new QueryableSortProvider(x => 
                x.AddDefaultFieldHandlers()
                 .AddFieldHandler<OrderByClauseSortHandler>()
                 .AddOperationHandler<NullsFirstSortOperationHandler>()
                 .AddOperationHandler<NullsLastSortOperationHandler>()));
        descriptor.BindRuntimeType<Book, Book_OrderByInput>();
    }
}