using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Homework_2021_03_25.Filters
{
    public class AuthorizationActionFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly String _permission;

        public AuthorizationActionFilter(String permission) {
            _permission = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            String role = filterContext.HttpContext.Session.GetString("role");

            if (!IsAuthorized(role)) {
                filterContext.Result = new UnauthorizedResult();
            }
        }

        private bool IsAuthorized(String role)
        {
            if (String.IsNullOrWhiteSpace(role)) return false;
            return role == _permission || role == "Admin";
        }
    }
}