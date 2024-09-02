using Microsoft.AspNetCore.Mvc;
using LessonSchedule.Data;
using LessonSchedule.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class TeachingHoursController : ControllerBase
{
    private readonly SchoolContext _context;

    public TeachingHoursController(SchoolContext context)
    {
        _context = context;
    }

    // GET: api/TeachingHours
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TeachingHour>>> GetTeachingHours()
    {
        return await _context.TeachingHours.ToListAsync();
    }

    // GET: api/TeachingHours/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TeachingHour>> GetTeachingHour(int id)
    {
        var teachingHour = await _context.TeachingHours.FindAsync(id);

        if (teachingHour == null)
        {
            return NotFound();
        }

        return teachingHour;
    }

    // POST: api/TeachingHours
    [HttpPost]
    public async Task<ActionResult<TeachingHour>> PostTeachingHour(TeachingHour teachingHour)
    {
        _context.TeachingHours.Add(teachingHour);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTeachingHour), new { id = teachingHour.TeachingHoursId }, teachingHour);
    }

    // PUT: api/TeachingHours/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTeachingHour(int id, TeachingHour teachingHour)
    {
        if (id != teachingHour.TeachingHoursId)
        {
            return BadRequest();
        }

        _context.Entry(teachingHour).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.TeachingHours.Any(e => e.TeachingHoursId == id))
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

    // DELETE: api/TeachingHours/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeachingHour(int id)
    {
        var teachingHour = await _context.TeachingHours.FindAsync(id);
        if (teachingHour == null)
        {
            return NotFound();
        }

        _context.TeachingHours.Remove(teachingHour);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
