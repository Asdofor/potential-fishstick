using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationalMonitoringSystem.Models
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(2, 5, ErrorMessage = "Оценка должна быть от 2 до 5")]
        [Display(Name = "Оценка")]
        public int Value { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Дата выставления")]
        public DateTime Date { get; set; }

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
