using System;
using System.Collections.Generic;
using App_2021_03_26.BusinessLogics;
using App_2021_03_26.Models;
using Microsoft.AspNetCore.Mvc;

namespace App_2021_03_26.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MemberController : Controller
    {
        private readonly IMemberHandler _memberHandler;
        public MemberController(IMemberHandler memberHandler)
        {
            _memberHandler = memberHandler;
        }

        [HttpGet]
        [Route("GetMemberByGender/{gender}")]
        public List<Member> GetMemberByGender(String gender)
        {
            return _memberHandler.GetMemberByGender(gender);
        }

        [HttpGet]
        [Route("GetOldestMember")]
        public Member GetOldestMember()
        {
            return _memberHandler.GetOldestMember();
        }

        [HttpGet]
        [Route("GetMemberFullNames")]
        public List<String> GetMemberFullNames()
        {
            return _memberHandler.GetMemberFullNames();
        }

        [HttpGet]
        [Route("FilterMemberByBirthYear")]
        public List<List<Member>> FilterMemberByBirthYear()
        {
            return _memberHandler.FilterMemberByBirthYear();
        }

        [HttpGet]
        [Route("FirstMemberInLocation/{location}")]
        public Member FirstMemberInLocation(String location)
        {
            return _memberHandler.FirstMemberInLocation(location);
        }
    }
}