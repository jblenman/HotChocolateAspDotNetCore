using HotChocolate.Data.Sorting;
using HotChocolateAspDotNetCore.ObjectTypes;

namespace HotChocolateAspDotNetCore.Configuration;

public class Book_OrderByInput : SortInputType<Book>
{
    protected override void Configure(ISortInputTypeDescriptor<Book> descriptor)
    {
        descriptor.Field(f => f.Id).Type<OrderByClauseSortInputType>();
    }
}