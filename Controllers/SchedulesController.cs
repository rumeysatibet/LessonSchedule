using Microsoft.AspNetCore.Mvc;
using LessonSchedule.Services;
using LessonSchedule.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class SchedulesController : ControllerBase
{
    private readonly ScheduleService _scheduleService;

    public SchedulesController(ScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Schedule>>> GetWeeklySchedules()
    {
        var schedules = await _scheduleService.GenerateWeeklySchedule();
        return Ok(schedules);
    }
}
