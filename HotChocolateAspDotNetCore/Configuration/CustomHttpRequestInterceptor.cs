using HotChocolate.AspNetCore;
using HotChocolate.Execution;

namespace HotChocolateAspDotNetCore.Configuration;

//public class CustomHttpRequestInterceptor : DefaultHttpRequestInterceptor
//{
//    public override ValueTask OnCreateAsync(HttpContext context, IRequestExecutor requestExecutor, IQueryRequestBuilder requestBuilder,
//        CancellationToken cancellationToken)
//    {
//        //requestBuilder.TryAddProperty("limit", 51);
//        return base.OnCreateAsync(context, requestExecutor, requestBuilder, cancellationToken);
//    }
//}