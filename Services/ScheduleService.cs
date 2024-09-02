using LessonSchedule.Data;
using LessonSchedule.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LessonSchedule.Services
{
    public class ScheduleService
    {
        private readonly SchoolContext _context;

        public ScheduleService(SchoolContext context)
        {
            _context = context;
        }

        public async Task<List<Schedule>> GenerateWeeklySchedule()
        {
            var schedules = new List<Schedule>();
            var teachers = await _context.Teachers.Include(t => t.Subject).ToListAsync();

            // Öğretmenlere göre haftalık ders programı oluştur
            foreach (var teacher in teachers)
            {
                // Örnek olarak her gün için saatler belirle
                for (int day = 0; day < 5; day++)
                {
                    schedules.Add(new Schedule
                    {
                        TeacherId = teacher.TeacherId,
                        DayOfWeek = day,
                        Hours = 8 // Sabit bir değer, gerçek uygulamada dinamik olmalı
                    });
                }
            }

            return schedules;
        }
    }
}
