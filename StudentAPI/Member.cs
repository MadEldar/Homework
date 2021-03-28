using System;
using System.ComponentModel.DataAnnotations;

namespace App_2021_03_26.Models
{
    public class Member : Person
    {
        [Display(Name = "Start date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EndDate { get; set; }
        public Member() {}
        public Member(int Id, string FirstName, string LastName, String Gender, DateTime DoB, string PhoneNumber,
                string BirthPlace, bool IsGraduated, DateTime StartDate, DateTime EndDate) : base(
                    Id, FirstName, LastName, Gender, DoB, PhoneNumber, BirthPlace, IsGraduated
        ){
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }
        public String GetStartDate() {
            return this.DoB.ToString("yyyy/MM/dd");
        }
        public String GetEndDate() {
            return this.DoB.ToString("yyyy/MM/dd");
        }
        public void Edit(Member edited) {
            base.Edit(edited);
            StartDate = edited.StartDate;
            EndDate = edited.EndDate;
        }
        public new bool CheckEmptyFields() {
            return base.CheckEmptyFields() ||
                CheckDefaultDate(StartDate) ||
                CheckDefaultDate(EndDate);
        }

        private static bool CheckDefaultDate(DateTime date) {
            return date == new DateTime();
        }
    }
}