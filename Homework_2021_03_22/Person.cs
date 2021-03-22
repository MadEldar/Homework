using System;

namespace Homework_2021_03_22
{
    public class Person
    {
        public String FirstName;
        public String LastName;
        public Genders Gender;
        public DateTime DoB;
        public String PhoneNumber;
        public String BirthPlace;
        public bool IsGraduated;

        public enum Genders {
            Male,
            Female
        }

        public Person(string FirstName, string LastName, Genders Gender, DateTime DoB, string PhoneNumber, string BirthPlace, bool IsGraduated){
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Gender = Gender;
            this.DoB = DoB;
            this.PhoneNumber = PhoneNumber;
            this.BirthPlace = BirthPlace;
            this.IsGraduated = IsGraduated;
        }

        public Person(){}

        public String GetFullName() {
            return "Name: " + this.FirstName + " " + this.LastName;
        }

        public String GetDateOfBirth() {
            return this.DoB.ToString("yyyy/MM/dd");
        }

        override
        public String ToString() {
            return GetFullName() +
                " Gender: " + this.Gender +
                " Date of Birth: " + GetDateOfBirth() +
                " Phone Number: " + this.PhoneNumber +
                " Birth Place: " + this.BirthPlace +
                " Is Graduated: " + (this.IsGraduated ? "Yes" : "No");
        }
    }
}