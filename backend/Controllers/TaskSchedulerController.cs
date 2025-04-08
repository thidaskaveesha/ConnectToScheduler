using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/tasks")]
public class TaskSchedulerController : ControllerBase
{
    private readonly ITaskSchedulerService _taskSchedulerService;

    public TaskSchedulerController(ITaskSchedulerService taskSchedulerService)
    {
        _taskSchedulerService = taskSchedulerService;
    }

    // Get All tasks schedule in the root folder ( specific user )
    [HttpGet]
    public IActionResult GetUserCreatedTasks()
    {
        var tasks = _taskSchedulerService.GetUserCreatedTasks();
        return Ok(tasks);
    }

    // Change task status on a specific task 
    [HttpPost("change-status")]
    public IActionResult ChangeTaskStatus([FromBody] ChangeTaskStateRequest request)
    {
        var response = _taskSchedulerService.ChangeTaskStatus(request);

        if (response.Status == "not found" || response.Status == "invalid")
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}
