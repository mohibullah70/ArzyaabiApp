using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace EZKARAPP.Extensions
{
    public static class IdentityExtensions
    {
        public static int GetPersonId(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;
            if (ci != null)
            {
                return ci.FindFirst("PersonId") == null ? 0 : int.Parse(ci.FindFirstValue("PersonId"));
            }
            return 0;
        }
    }
}