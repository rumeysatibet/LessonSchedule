using LessonSchedule.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LessonSchedule.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public List<Teacher>? Teachers { get; set; }
    }
}
