using System;

namespace Homework_2021_03_22
{
    public class Member : Person
    {
        public DateTime StartDate;
        public DateTime EndDate;

        public Member(
            string firstName,
            string lastName,
            Person.Genders gender,
            DateTime dob,
            string phoneNumber,
            string birthPlace,
            bool isGraduated,
            DateTime StartDate,
            DateTime EndDate
        ) : base(firstName, lastName, gender, dob, phoneNumber, birthPlace, isGraduated)
        {
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }

        override
        public String ToString()
        {
            return GetFullName() +
                " Gender: " + this.Gender +
                " Date of Birth: " + GetDateOfBirth() +
                " Phone Number: " + this.PhoneNumber +
                " Birth Place: " + this.BirthPlace +
                " Is Graduated: " + (this.IsGraduated ? "Yes" : "No") +
                " Start Date: " + this.StartDate.ToString("yyyy/MM/dd") +
                " End Date: " + this.EndDate.ToString("yyyy/MM/dd");
        }
    }
}