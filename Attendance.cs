using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationalMonitoringSystem.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Дата занятия")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Присутствие")]
        public bool IsPresent { get; set; } // true - был, false - пропуск

        [Required]
        [Display(Name = "Студент")]
        public int StudentId { get; set; }
        
        [ForeignKey("StudentId")]
        public virtual Student? Student { get; set; }

        [Required]
        [Display(Name = "Дисциплина")]
        public int SubjectId { get; set; }
        
        [ForeignKey("SubjectId")]
        public virtual Subject? Subject { get; set; }
    }
}
