using System;
using System.ComponentModel.DataAnnotations;

namespace Homework_2021_03_25.Models
{
    public class Member
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Date of birth is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DoB { get; set; }
        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Birth place")]
        [Required(ErrorMessage = "Birth place is required")]
        public string BirthPlace { get; set; }
        [Display(Name = "Is graduated")]
        public bool IsGraduated { get; set; }
        [Display(Name = "Start date")]
        [Required(ErrorMessage = "Start date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End date")]
        [Required(ErrorMessage = "End date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EndDate { get; set; }
        public Member() {}
        public Member(int Id, string FirstName, string LastName, string Gender, DateTime DoB, string PhoneNumber,
                string BirthPlace, bool IsGraduated, DateTime StartDate, DateTime EndDate){
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Gender = Gender;
            this.DoB = DoB;
            this.PhoneNumber = PhoneNumber;
            this.BirthPlace = BirthPlace;
            this.IsGraduated = IsGraduated;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }
        public string GetFullName() {
            return $"{FirstName} {LastName}";
        }
        public string GetDateOfBirth() {
            return DoB.ToString("yyyy/MM/dd");
        }
        public string GetStartDate() {
            return StartDate.ToString("yyyy/MM/dd");
        }
        public string GetEndDate() {
            return EndDate.ToString("yyyy/MM/dd");
        }

        public void Edit(Member edited) {
            FirstName = edited.FirstName;
            LastName = edited.LastName;
            Gender = edited.Gender;
            DoB = edited.DoB;
            PhoneNumber = edited.PhoneNumber;
            BirthPlace = edited.BirthPlace;
            IsGraduated = edited.IsGraduated;
            StartDate = edited.StartDate;
            EndDate = edited.EndDate;
        }
    }
}