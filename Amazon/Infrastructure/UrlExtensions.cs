using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//url extension page, hilton will explain the code and what it means later

namespace Amazon.Infrastructure
{
    public static class UrlExtensions
    {
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
    }
}
