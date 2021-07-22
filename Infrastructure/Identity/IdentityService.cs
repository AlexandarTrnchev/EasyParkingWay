using Application.Common.Interfaces;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _httpContext;

        public IdentityService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public string GetCurrentUserId()
        {
            return _httpContext.HttpContext?.GetUserId();
        }
    }
}
