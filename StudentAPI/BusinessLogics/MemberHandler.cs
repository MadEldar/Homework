using System;
using System.Collections.Generic;
using System.Linq;
using App_2021_03_26.Models;

namespace App_2021_03_26.BusinessLogics
{
    public class MemberHandler : IMemberHandler
    {
        private readonly List<Member> memberList = new();
        public MemberHandler()
        {
            SeedData();
        }

        public List<List<Member>> FilterMemberByBirthYear()
        {
            List<List<Member>> result = new();
            List<Member> greaterThan = new();
            List<Member> lessThan = new();
            List<Member> equal = new();
            foreach (Member m in memberList)
            {
                switch(m.DoB.Year)
                {
                    case 2000:
                        equal.Add(m);
                        break;
                    case > 2000:
                        greaterThan.Add(m);
                        break;
                    case < 2000:
                        lessThan.Add(m);
                        break;
                }
            }
            result.Add(equal);
            result.Add(greaterThan);
            result.Add(lessThan);
            return result;
        }

        public Member FirstMemberInLocation(string location)
        {
            return memberList.Find(m => m.BirthPlace.Equals(location, StringComparison.CurrentCultureIgnoreCase));
        }

        public List<Member> GetMemberByGender(string gender)
        {
            return memberList.FindAll(m => m.Gender.Equals(gender, StringComparison.CurrentCultureIgnoreCase));
        }

        public List<string> GetMemberFullNames()
        {
            return memberList.ToArray().Select(m => m.GetFullName()).ToList();
        }

        public Member GetOldestMember()
        {
            return memberList.OrderBy(m => m.DoB).FirstOrDefault();
        }
        private void SeedData() {
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
    }
}