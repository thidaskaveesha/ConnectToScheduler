using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32.TaskScheduler;
using System.Collections.Generic;

[ApiController]
[Route("api/tasks")]
public class TaskSchedulerController : ControllerBase
{
    [HttpGet]
    public IActionResult GetTasks()
    {
        List<string> tasks = new List<string>();

        // Connect to the Task Scheduler
        TaskService ts = new TaskService();
        foreach (Task task in ts.AllTasks)
        {
            tasks.Add(task.Name);
        }

        return Ok(tasks);
    }
}
