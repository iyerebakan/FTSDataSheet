using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace WebUI.Extensions
{
    public class UserIdentityInfo
    {
        private static IHttpContextAccessor _httpContextAccessor;
        
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static HttpContext Current => _httpContextAccessor.HttpContext;
        private static ClaimsIdentity identity => (ClaimsIdentity)_httpContextAccessor.HttpContext.User.Identity;
        public static string Id
        {
            get
            {
                return identity.Claims.FirstOrDefault(k => k.Type == ClaimTypes.NameIdentifier).Value;
            }
        }

        public static string Email
        {
            get
            {
                return identity.Claims.FirstOrDefault(k => k.Type == ClaimTypes.Email).Value;
            }
        }

        public static string Name
        {
            get
            {
                return identity.Claims.FirstOrDefault(k => k.Type == ClaimTypes.Name).Value;
            }
        }

        public static List<string> Roles
        {
            get
            {
                return identity.Claims.Where(k => k.Type == ClaimTypes.Role).Select(k => k.Value).ToList();
            }
        }

    }
}
