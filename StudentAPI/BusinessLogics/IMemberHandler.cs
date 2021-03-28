using System;
using System.Collections.Generic;
using App_2021_03_26.Models;

namespace App_2021_03_26.BusinessLogics
{
    public interface IMemberHandler
    {
        //1.	Return a list of members who is Male
        List<Member> GetMemberByGender(String gender);
        //2.	Return the oldest one based on “Age” (if return more than one record then select first record)
        Member GetOldestMember();
        //3.	Return a new list that contains Full Name only ( Full Name = Last Name + First Name)
        List<String> GetMemberFullNames();
        //4.	Return 3 lists:
        //      o	List of members who has birth year is 2000
        //      o	List of members who has birth year greater than 2000
        //      o	List of members who has birth year less than 2000
        List<List<Member>> FilterMemberByBirthYear();
        //5.	Return the first person who was born in Ha Noi.
        Member FirstMemberInLocation(String location);
    }
}