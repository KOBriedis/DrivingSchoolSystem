using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace DrivingSchoolSystem.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        [BindProperty, DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        public DateTime RegistrationTime { get; set; } = DateTime.Now;
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public TrainingCategory TrainingCategory { get; set; }
        [Required]
        public Enroll Enroll { get; set; }
        public DateTime? ExamDateTime { get; set; }
    }

    public enum TrainingCategory
    {
        A,
        A1,
        B,
        BE,
        C1,
        C1E,
        C,
        CE,
        D1,
        D1E,
        D,
        DE
    }


    public enum Enroll
    {
        Theory,
        [Display(Name = "Practical driving lesson")]
        PracticalDrivingLesson
    }
}
