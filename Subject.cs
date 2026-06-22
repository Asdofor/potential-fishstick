using System.ComponentModel.DataAnnotations;

namespace EducationalMonitoringSystem.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название дисциплины")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Семестр")]
        [Range(1, 8)]
        public int Semester { get; set; }

        [Display(Name = "Количество часов")]
        public int Hours { get; set; }

        [Display(Name = "Преподаватель")]
        public int? TeacherId { get; set; }

        public virtual Teacher? Teacher { get; set; }
        public virtual ICollection<Grade>? Grades { get; set; }
    }
}