using LibraryAPI.Enums;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Filters
{
    public class AuthorizeAtrribute : TypeFilterAttribute
    {
        public AuthorizeAtrribute(UserRole permission) : base(typeof(AuthorizationActionFilter))
        {
            Arguments = new object[] { permission };
        }
    }
}