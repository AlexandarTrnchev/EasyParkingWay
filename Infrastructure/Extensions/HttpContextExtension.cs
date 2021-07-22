using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Extensions
{
    public static class HttpContextExtension
    {
        public static string GetUserId(this HttpContext context)
        {
            return context?.User?.Claims.FirstOrDefault(x => x.Type == Constants.UserIdClaimType)?.Value;
        }
    }
}
