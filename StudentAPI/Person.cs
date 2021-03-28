using System;
using System.ComponentModel.DataAnnotations;

namespace App_2021_03_26
{
    public class Person
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "First name")]
        public String FirstName { get; set; }
        [Display(Name = "Last name")]
        public String LastName { get; set; }
        public String Gender { get; set; }
        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DoB { get; set; }
        [Display(Name = "Phone number")]
        public String PhoneNumber { get; set; }
        [Display(Name = "Birth place")]
        public String BirthPlace { get; set; }
        [Display(Name = "Is graduated")]
        public bool IsGraduated { get; set; }
        public Person() {}
        public Person(int Id, string FirstName, string LastName, String Gender, DateTime DoB, string PhoneNumber,
                string BirthPlace, bool IsGraduated){
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Gender = Gender;
            this.DoB = DoB;
            this.PhoneNumber = PhoneNumber;
            this.BirthPlace = BirthPlace;
            this.IsGraduated = IsGraduated;
        }
        public String GetFullName() {
            return $"{this.FirstName} {this.LastName}";
        }
        public String GetDateOfBirth() {
            return this.DoB.ToString("yyyy/MM/dd");
        }

        public void Edit(Person edited) {
            FirstName = edited.FirstName;
            LastName = edited.LastName;
            Gender = edited.Gender;
            DoB = edited.DoB;
            PhoneNumber = edited.PhoneNumber;
            BirthPlace = edited.BirthPlace;
            IsGraduated = edited.IsGraduated;
        }
        public bool CheckEmptyFields() {
            return String.IsNullOrWhiteSpace(FirstName) ||
                String.IsNullOrWhiteSpace(LastName) ||
                String.IsNullOrWhiteSpace(Gender) ||
                String.IsNullOrWhiteSpace(PhoneNumber) ||
                String.IsNullOrWhiteSpace(BirthPlace) ||
                CheckDefaultDate(DoB);
        }

        private static bool CheckDefaultDate(DateTime date) {
            return date == new DateTime();
        }
    }
}