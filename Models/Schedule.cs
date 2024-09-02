using LessonSchedule.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LessonSchedule.Models
{
    public class Schedule
    {
        public int TeacherId { get; set; }
        public int DayOfWeek { get; set; }
        public int Hours { get; set; }
    }
}
