using LessonSchedule.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LessonSchedule.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string? Name { get; set; }
        public int SubjectId { get; set; }

        [ForeignKey("SubjectId")]
        public Subject? Subject { get; set; }
        public List<TeachingHour>? TeachingHours { get; set; }
    }
}
