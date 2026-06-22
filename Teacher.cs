using System.ComponentModel.DataAnnotations;

namespace EducationalMonitoringSystem.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Отчество")]
        public string? MiddleName { get; set; }

        [Display(Name = "Должность")]
        public string? Position { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string? Email { get; set; }

        [Display(Name = "ФИО")]
        public string FullName => $"{LastName} {FirstName} {MiddleName}".Trim();
    }
}