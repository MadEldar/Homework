using System;
using System.Threading.Tasks;
using LibraryAPI.Enums;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LibraryAPI.Filters
{
    public class AuthorizationActionFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly UserRole _permission;
        private readonly CurrentUserService _service;
        public AuthorizationActionFilter(UserRole permission, CurrentUserService service) {
            _permission = permission;
            _service = service;
        }

        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            var headers = filterContext.HttpContext.Request.Headers;

            if (!headers.ContainsKey("AuthToken") || !IsAuthorized(headers["AuthToken"]))
            {
                filterContext.Result = new UnauthorizedResult();
            }
        }

        private bool IsAuthorized(string token)
        {
            User user = _service.GetCurrentUser(token);

            if (user == null) return false;

            return user.Role == UserRole.Admin || user.Role == _permission;
        }
    }
}