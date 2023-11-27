using HotChocolate.Data.Sorting;
using HotChocolateAspDotNetCore;
using HotChocolateAspDotNetCore.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<NullsOrderSortEnumType>()
    .AddType<DirectionSortEnumType>()
    .AddType<OrderByClauseSortInputType>()
    .AddGlobalObjectIdentification()
    .AddConvention<ISortConvention, CustomSortConvention>()
    .AddSorting()
    .AddFiltering();

//builder.Services
//    .AddSingleton<IParameterExpressionBuilder>(
//        new CustomParameterExpressionBuilder<int?>(
//            c => c.GetGlobalValue<int?>("limit"),
//            p => p.Name.EqualsOrdinal("limit")));

var app = builder.Build();

app.UseRouting();

app.MapGraphQLHttp("/graphql/");
app.MapBananaCakePop("/graphql/");

app.Run();