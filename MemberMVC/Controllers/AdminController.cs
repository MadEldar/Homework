using System;
using Homework_2021_03_25.Filters;
using Homework_2021_03_25.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homework_2021_03_25.Controllers
{
    public class AdminController : Controller
    {
        public readonly MemberMVCContext _context;
        public AdminController(MemberMVCContext context) {
            _context = context;
        }
        [AuthorizeAtrribute("Admin")]
        [HttpGet("/admin/memberlist")]
        public IActionResult MemberList()
        {
            return View("MemberList", _context.Members);
        }
        [AuthorizeAtrribute("Admin")]
        [HttpGet("/admin/membercreate")]
        public IActionResult MemberCreate()
        {
            return View("MemberCreate");
        }
        [AuthorizeAtrribute("Admin")]
        [HttpPost("/admin/membercreate")]
        public IActionResult MemberCreatePost(Member member)
        {
            if(!ModelState.IsValid)
            {
                return View("MemberCreate");
            }
            else
            {
                _context.Members.Add(member);
                _context.SaveChanges();
                return RedirectToAction("MemberDetails", "Admin", new {id = member.Id});
            }
        }
        [AuthorizeAtrribute("Admin")]
        [HttpGet("/admin/memberdetails/{id}")]
        public IActionResult MemberDetails(int id)
        {
            return View("MemberDetails", _context.Members.Find(id));
        }
        [AuthorizeAtrribute("Admin")]
        [HttpGet("/admin/memberedit/{id}")]
        public IActionResult MemberEdit(int id)
        {
            return View("MemberEdit", _context.Members.Find(id));
        }
        [AuthorizeAtrribute("Admin")]
        [HttpPost("/admin/memberedit/{id}")]
        public IActionResult MemberEditPost(int id, Member edited)
        {
            Member member = _context.Members.Find(id);
            if (member == null || !ModelState.IsValid)
            {
                return View("MemberCreate");
            }
            else
            {
                member.Edit(edited);
                _context.SaveChanges();
                return RedirectToAction("MemberDetails", "Admin", new {id = member.Id});
            }
        }
        [HttpGet("/admin/memberdelete/{id}")]
        public IActionResult MemberDelete(int id)
        {
            Member member = _context.Members.Find(id);
            if (member != null)
            {
                _context.Members.Remove(member);
                _context.SaveChanges();
            }
            return RedirectToAction("MemberList", "Admin");
        }
    }
}