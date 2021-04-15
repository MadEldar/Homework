using System.Linq;
using System.Collections.Generic;
using LibraryAPI.Models;
using LibraryAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/admin/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserRepository _repo;

        public UserController(UserRepository repo)
        {
            _repo = repo;
        }

        // [HttpGet(":id")]
        // public User GetUserById(int id)
        // {
        //     return _repo.GetUserById(id);
        // }

        // [HttpGet("list")]
        // public List<User> GetUserById()
        // {
        //     return _repo.GetUserList();
        // }

        // [HttpPost("")]
        // public bool CreateUser(User user)
        // {
        //     return _repo.CreateUser(user);
        // }

        // [HttpPut("")]
        // public bool EditUser(User editedUser)
        // {
        //     return _repo.EditUser(editedUser);
        // }

        // [HttpDelete("")]
        // public bool DeleteUser(int id)
        // {
        //     return _repo.DeleteUser(id);
        // }
    }
}