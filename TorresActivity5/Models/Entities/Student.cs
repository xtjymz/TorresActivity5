using System;
using System.ComponentModel.DataAnnotations;

namespace TorresActivity5.Models.Entities
{
    public class Student
    {
        // Primary Key [2]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(100)]
        public string LastName { get; set; }

        // Optional fields are marked with a '?' so they allow null values
        public string? MiddleInitial { get; set; }
        public string? Suffix { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        public string CivilStatus { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string EmergencyContactFirstName { get; set; }

        [Required]
        public string EmergencyContactLastName { get; set; }

        [Required]
        public string EmergencyContactRelationship { get; set; }

        [Required]
        public string EmergencyContactPhoneNumber { get; set; }

        public string FullName => $"{FirstName} {MiddleInitial} {LastName} {Suffix}".Trim();

        public int Age => DateTime.Today.Year - Birthdate.Year - (DateTime.Today.DayOfYear < Birthdate.DayOfYear ? 1 : 0);

        public string EmergencyContactName => $"{EmergencyContactFirstName} {EmergencyContactLastName}";
    }
}