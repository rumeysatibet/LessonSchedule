using LessonSchedule.Models;
using Microsoft.EntityFrameworkCore;

namespace LessonSchedule.Data
{
    public class SchoolContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<AvailableDay> AvailableDays { get; set; }
        // Diğer DbSet'ler...

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ek yapılandırmalar
        }
        public DbSet<TeachingHour>? TeachingHours { get; set; }

    }
}
