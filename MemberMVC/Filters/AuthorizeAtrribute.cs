using System;
using Microsoft.AspNetCore.Mvc;

namespace Homework_2021_03_25.Filters
{
    public class AuthorizeAtrribute : TypeFilterAttribute
    {
        public AuthorizeAtrribute(String permission) : base(typeof(AuthorizationActionFilter))
        {
            Arguments = new object[] { permission };
        }
    }
}