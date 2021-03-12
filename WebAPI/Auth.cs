using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
namespace WebAPI
{
    public static class Auth
    {
        private static readonly string PrivateAdminKey = "mysuperscretadminkeymysuperscretadminkey";

        public static bool IsAdmin(HttpRequest request)
        {
            var header = request.Headers["Authentication"];
            if(String.IsNullOrEmpty(header))
            {
                return false;
            }
            else if(new PasswordHasher().VerifyHashedPassword(header,PrivateAdminKey) == PasswordVerificationResult.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
