using System.ComponentModel.DataAnnotations;

namespace EducationalMonitoringSystem.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название группы")]
        [Display(Name = "Название группы")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Курс")]
        [Range(1, 4, ErrorMessage = "Курс от 1 до 4")]
        public int Course { get; set; }

        [Display(Name = "Специальность")]
        public string? Specialty { get; set; }

        public virtual ICollection<Student>? Students { get; set; }
    }
}