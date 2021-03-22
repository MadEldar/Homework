using System;
using System.Collections.Generic;

namespace App_2021_03_22
{

    public class Member {
        public String firstName;
        public String lastName;
        public Genders gender;
        public DateTime dob;
        public String phoneNumber;
        public String birthPlace;
        public bool isGraduated;

        public enum Genders {
            Male,
            Female
        }

        public Member(string firstName, string lastName, Genders gender, DateTime dob, string phoneNumber, string birthPlace, bool isGraduated){
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.dob = dob;
            this.phoneNumber = phoneNumber;
            this.birthPlace = birthPlace;
            this.isGraduated = isGraduated;
        }

        public Member(){}

        public String getFullName() {
            return "Name: " + this.firstName + " " + this.lastName;
        }

        public String getDateOfBirth() {
            return this.dob.ToString("yyyy/MM/dd");
        }

        public String toString() {
            return getFullName() +
                " Gender: " + this.gender +
                " Date of Birth: " + getDateOfBirth() +
                " Phone Number: " + this.phoneNumber +
                " Birth Place: " + this.birthPlace +
                " Is Graduated: " + (this.isGraduated ? "Yes" : "No");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Member> members = new List<Member>();
            members.Add(new Member("Vinh", "Truong", Member.Genders.Male, new DateTime(2001, 1, 1), "0931252314", "Vietnam", false));
            members.Add(new Member("Hai", "Le", Member.Genders.Male, new DateTime(1998, 1, 6), "0934251231", "Ha Noi", false));
            members.Add(new Member("Lop", "Bui", Member.Genders.Female, new DateTime(2000, 1, 1), "0934251234", "Vietnam", false));
            members.Add(new Member("Thang", "Le", Member.Genders.Male, new DateTime(1995, 1, 1), "0934251234", "Ha Noi", false));

            // 1.
            Console.WriteLine("1.");
            printMemberInfo(members.FindAll(member => member.gender == Member.Genders.Male));

            // 2.
            Console.WriteLine("2.");
            Console.WriteLine(getOldestMemeber(members).toString());

            // 3.
            Console.WriteLine("3.");
            List<string> memberNames = new List<string>();

            foreach (var member in members)
            {
                memberNames.Add(member.getFullName());
            }

            foreach (var name in memberNames) {
                Console.WriteLine(name);
            }

            Console.WriteLine("");

            // 4.
            Console.WriteLine("\n4.");
            List<Member> bornIn2000 = new List<Member>();
            List<Member> youngerThan2000 = new List<Member>();
            List<Member> olderThan2000 = new List<Member>();
            foreach (Member member in members) {
                switch (member.dob.Year) {
                    case 2000:
                        bornIn2000.Add(member);
                        break;
                    case >2000:
                        youngerThan2000.Add(member);
                        break;
                    case <2000:
                        olderThan2000.Add(member);
                        break;
                }
            }
            printMemberInfo(bornIn2000);
            printMemberInfo(youngerThan2000);
            printMemberInfo(olderThan2000);

            // 5.
            Console.WriteLine("5.");
            Console.WriteLine(getOldestMemeber(getMemberFrom(members, "Ha Noi")).toString());
        }

        private static void printMemberInfo (List<Member> members) {
            foreach (Member member in members) {
                Console.WriteLine(member.toString());
            }
            Console.WriteLine("");
        }

        private static Member getOldestMemeber(List<Member> members) {
            Member oldest = new Member();
            oldest.dob = DateTime.Now;

            foreach (var member in members)
            {
                if (member.dob < oldest.dob) {
                    oldest = member;
                }
            }

            return oldest;
        }

        private static List<Member> getMemberFrom (List<Member> members, String location) {
            List<Member> membersFromLocation = new List<Member>();

            foreach (var member in members) {
                if (member.birthPlace == location) {
                    membersFromLocation.Add(member);
                }
            }

            return membersFromLocation;
        }
    }
}
