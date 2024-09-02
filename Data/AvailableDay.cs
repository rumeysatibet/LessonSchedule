using LessonSchedule.Models;
using System.ComponentModel.DataAnnotations;

public class AvailableDay
{
    public int Id { get; set; }

    [Required]
    public int TeacherId { get; set; }

    [Required]
    public DayOfWeek DayOfWeek { get; set; }

    [Range(0, 23)]
    public int StartHour { get; set; }

    [Range(0, 23)]
    public int EndHour { get; set; }

    public Teacher Teacher? { get; set; }
}
