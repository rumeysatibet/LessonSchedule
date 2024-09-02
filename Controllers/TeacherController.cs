using Microsoft.AspNetCore.Mvc;
using LessonSchedule.Data;
using LessonSchedule.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class TeachersController : ControllerBase
{
    private readonly SchoolContext _context;

    public TeachersController(SchoolContext context)
    {
        _context = context;
    }

    // GET: api/Teachers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
    {
        return await _context.Teachers.ToListAsync();
    }

    // GET: api/Teachers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Teacher>> GetTeacher(int id)
    {
        var teacher = await _context.Teachers.FindAsync(id);

        if (teacher == null)
        {
            return NotFound();
        }

        return teacher;
    }

    // POST: api/Teachers
    [HttpPost]
    public async Task<ActionResult<Teacher>> PostTeacher(Teacher teacher)
    {
        _context.Teachers.Add(teacher);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTeacher), new { id = teacher.TeacherId }, teacher);
    }

    // PUT: api/Teachers/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTeacher(int id, Teacher teacher)
    {
        if (id != teacher.TeacherId)
        {
            return BadRequest();
        }

        _context.Entry(teacher).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Teachers.Any(e => e.TeacherId == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Teachers/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeacher(int id)
    {
        var teacher = await _context.Teachers.FindAsync(id);
        if (teacher == null)
        {
            return NotFound();
        }

        _context.Teachers.Remove(teacher);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    [HttpPost("availability")]
    public async Task<IActionResult> AddOrUpdateAvailability(AvailableDay availableDay)
    {
        var existingDay = await _context.AvailableDays
            .FirstOrDefaultAsync(ad => ad.TeacherId == availableDay.TeacherId && ad.DayOfWeek == availableDay.DayOfWeek);

        if (existingDay != null)
        {
            existingDay.StartHour = availableDay.StartHour;
            existingDay.EndHour = availableDay.EndHour;
        }
        else
        {
            _context.AvailableDays.Add(availableDay);
        }

        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpGet("availability/{teacherId}")]
    public async Task<ActionResult<List<AvailableDay>>> GetAvailability(int teacherId)
    {
        var availability = await _context.AvailableDays
                                    .Where(ad => ad.TeacherId == teacherId).ToListAsync();
        return Ok(availability);
    }


}
