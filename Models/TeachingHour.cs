using LessonSchedule.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LessonSchedule.Models
{
    public class TeachingHour
    {
        [Key]
        public int TeachingHoursId { get; set; }
        public int TeacherId { get; set; }
        public string? DayOfWeek { get; set; }
        public int NumberOfHours { get; set; }

        [ForeignKey("TeacherId")]
        public Teacher? Teacher { get; set; }
    }
}
