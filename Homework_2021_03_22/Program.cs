using System;
using System.Linq;
using System.Collections.Generic;

namespace Homework_2021_03_22
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Member> memberList = new List<Member>
            {
                new Member("Hai", "Le", Person.Genders.Male, new DateTime(1998, 1, 6), "0934251231", "Ha Noi", false, new DateTime(2021, 3, 15), new DateTime(2021, 6, 15)),
                new Member("Vinh", "Truong", Person.Genders.Male, new DateTime(2001, 12, 1), "0931252314", "Ha Noi", false, new DateTime(2021, 3, 15), new DateTime(2021, 6, 15)),
                new Member("Trang", "Bui", Person.Genders.Female, new DateTime(2000, 4, 9), "0934251234", "Ha Noi", false, new DateTime(2021, 3, 15), new DateTime(2021, 6, 15)),
                new Member("Thang", "Le", Person.Genders.Male, new DateTime(1995, 5, 2), "0934251234", "Ha Noi", false, new DateTime(2021, 3, 15), new DateTime(2021, 6, 15)),
                new Member("Hanh", "Vu", Person.Genders.Female, new DateTime(1994, 9, 1), "0937582931", "Hai Phong", false, new DateTime(2021, 3, 15), new DateTime(2021, 6, 15)),
                new Member("Anh", "Tran", Person.Genders.Male, new DateTime(2002, 8, 4), "0931751231", "Can Tho", false, new DateTime(2021, 3, 23), new DateTime(2021, 6, 15))
            };

            // 1.
            Console.WriteLine("1.");
            List<Member> maleMembers = memberList.FindAll(m => m.Gender == Person.Genders.Male);

            printMemberInfo(maleMembers);

            // 2.
            Console.WriteLine("2.");
            Member oldestMember = getOldestMemeber(memberList);

            Console.WriteLine(oldestMember.ToString());

            // 3.
            Console.WriteLine("\n3.");
            List<String> fullNameList = memberList.Select(m => m.GetFullName()).ToList();

            foreach (String name in fullNameList)
            {
                Console.WriteLine(name);
            }

            // 4.
            Console.WriteLine("\n4.");
            List<Member> bornIn2000 = new List<Member>();
            List<Member> youngerThan2000 = new List<Member>();
            List<Member> olderThan2000 = new List<Member>();
            foreach (Member member in memberList)
            {
                switch (member.DoB.Year)
                {
                    case 2000:
                        bornIn2000.Add(member);
                        break;
                    case > 2000:
                        youngerThan2000.Add(member);
                        break;
                    case < 2000:
                        olderThan2000.Add(member);
                        break;
                }
            }
            printMemberInfo(bornIn2000);
            printMemberInfo(youngerThan2000);
            printMemberInfo(olderThan2000);

            // 5.
            Console.WriteLine("5.");
            Member firstInHanoi = getOldestMemeber(getMembersFrom(memberList, "Ha Noi"));
            Console.WriteLine(firstInHanoi.ToString());

            // 6.
            Console.WriteLine("\n6.");
            var earlyMembers = memberList.FindAll(m => m.StartDate < new DateTime(2021, 3, 22));

            printMemberInfo(earlyMembers);
        }

        private static void printMemberInfo(List<Member> members)
        {
            foreach (Member member in members)
            {
                Console.WriteLine(member.ToString());
            }
            Console.WriteLine("");
        }

        private static Member getOldestMemeber(List<Member> members)
        {
            Member oldest = (from m in members
                            select m ).OrderBy(m => m.DoB).AsEnumerable().FirstOrDefault();

            return oldest;
        }

        private static List<Member> getMembersFrom(List<Member> members, String location)
        {
            List<Member> membersFromLocation = new List<Member>();

            foreach (var member in members)
            {
                if (member.BirthPlace == location)
                {
                    membersFromLocation.Add(member);
                }
            }

            return membersFromLocation;
        }
    }
}
