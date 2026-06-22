using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationalMonitoringSystem.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите фамилию")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Отчество")]
        public string? MiddleName { get; set; }

        [Required]
        [Display(Name = "Номер зачетной книжки")]
        public string StudentCardNumber { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Дата поступления")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Группа")]
        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group? Group { get; set; }

        public virtual ICollection<Grade>? Grades { get; set; }
        public virtual ICollection<Attendance>? Attendances { get; set; }

        [Display(Name = "ФИО")]
        public string FullName => $"{LastName} {FirstName} {MiddleName}".Trim();
    }
}