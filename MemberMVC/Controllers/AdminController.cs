using System;
using System.Collections.Generic;
using Homework_2021_03_25.Filters;
using Homework_2021_03_25.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homework_2021_03_25.Controllers
{
    public class AdminController : Controller
    {
        public static List<Member> memberList = new();
        public AdminController() {
            if (memberList.Count == 0)
            {
                memberList.Add(new Member(1, "Hai", "Le", "Male", new DateTime(1998, 1, 6), "0934251231", "Ha Noi", false, new DateTime(2021, 3, 15), new DateTime(2021, 6, 15)));
                memberList.Add(new Member(2, "Vinh", "Truong", "Male", new DateTime(2001, 12, 1), "0931252314", "Ha Noi", false, new DateTime(2021, 3, 15), new DateTime(2021, 6, 15)));
                memberList.Add(new Member(3, "Trang", "Bui", "Female", new DateTime(2000, 4, 9), "0934251234", "Ha Noi", false, new DateTime(2021, 3, 15), new DateTime(2021, 6, 15)));
                memberList.Add(new Member(4, "Thang", "Le", "Male", new DateTime(1995, 5, 2), "0934251234", "Ha Noi", false, new DateTime(2021, 3, 15), new DateTime(2021, 6, 15)));
                memberList.Add(new Member(5, "Hanh", "Vu", "Female", new DateTime(1994, 9, 1), "0937582931", "Hai Phong", false, new DateTime(2021, 3, 15), new DateTime(2021, 6, 15)));
                memberList.Add(new Member(6, "Anh", "Tran", "Male", new DateTime(2002, 8, 4), "0931751231", "Can Tho", false, new DateTime(2021, 3, 23), new DateTime(2021, 6, 15)));
            }
        }
        [AuthorizeAtrribute("Admin")]
        [HttpGet("/admin/memberlist")]
        public IActionResult MemberList()
        {
            return View("MemberList", memberList);
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
            if (memberList.Find(m => m.GetFullName() == member.GetFullName()) != null)
            {
                Console.WriteLine("Member already existed.");
                return RedirectToAction("MemberCreate", "Admin");
            }
            else if(member.CheckEmptyFields())
            {
                Console.WriteLine("Please fill out every field!");
                return RedirectToAction("MemberCreate", "Admin");
            }
            else
            {
                member.Id = memberList[^1].Id + 1;
                memberList.Add(member);
                return RedirectToAction("MemberDetails", "Admin", new {id = member.Id});
            }
        }
        [AuthorizeAtrribute("Admin")]
        [HttpGet("/admin/memberdetails/{id}")]
        public IActionResult MemberDetails(int id)
        {
            return View("MemberDetails", memberList.Find(m => m.Id == id));
        }
        [AuthorizeAtrribute("Admin")]
        [HttpGet("/admin/memberedit/{id}")]
        public IActionResult MemberEdit(int id)
        {
            return View("MemberEdit", memberList.Find(m => m.Id == id));
        }
        [AuthorizeAtrribute("Admin")]
        [HttpPost("/admin/memberedit/{id}")]
        public IActionResult MemberEditPost(int id, Member edited)
        {
            Member member = memberList.Find(m => m.Id == id);
            if (member == null)
            {
                Console.WriteLine("Cannot find member.");
                return RedirectToAction("MemberEdit", "Admin", new { id });
            }
            else if (edited?.CheckEmptyFields() == true)
            {
                Console.WriteLine("Please fill out every field!");
                return RedirectToAction("MemberEdit", "Admin", new { id });
            }
            else
            {
                member.Edit(edited);
                return RedirectToAction("MemberDetails", "Admin", new {id = member.Id});
            }
        }
        [HttpGet("/admin/memberdelete/{id}")]
        public IActionResult MemberDelete(int id)
        {
            Member member = memberList.Find(m => m.Id == id);
            if (member != null)
            {
                memberList.Remove(member);
            }
            return RedirectToAction("MemberList", "Admin");
        }
    }
}