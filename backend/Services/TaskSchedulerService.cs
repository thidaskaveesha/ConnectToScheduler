using backend.Models;
using Microsoft.Win32.TaskScheduler;
using Task = Microsoft.Win32.TaskScheduler.Task;

namespace backend.Services
{
    public class TaskSchedulerService : ITaskSchedulerService
    {
        public List<TaskResponse> GetUserCreatedTasks()
        {
            var userTasks = new List<TaskResponse>();

            using (TaskService ts = new TaskService())
            {
                foreach (Task task in ts.RootFolder.Tasks)
                {
                    userTasks.Add(new TaskResponse
                    {
                        Name = task.Name,
                        Status = task.State.ToString(),
                        NextRunTime = task.NextRunTime,
                        LastRunTime = task.LastRunTime
                    });
                }
            }

            return userTasks;
        }

        public ChangeTaskStatusResponse ChangeTaskStatus(ChangeTaskStateRequest request)
        {
            using (TaskService ts = new TaskService())
            {
                Task targetTask = null;

                foreach (Task task in ts.RootFolder.Tasks)
                {
                    if (task.Name == request.TaskName)
                    {
                        targetTask = task;
                        break;
                    }
                }

                if (targetTask == null)
                {
                    return new ChangeTaskStatusResponse
                    {
                        TaskName = request.TaskName,
                        Status = "not found",
                        Message = $"Task with name '{request.TaskName}' not found."
                    };
                }

                string message;
                switch (request.Status.ToLower())
                {
                    case "run":
                        targetTask.Run();
                        message = "Task started successfully.";
                        break;

                    case "end":
                        targetTask.Stop();
                        message = "Task stopped successfully.";
                        break;

                    case "enable":
                        targetTask.Enabled = true;
                        message = "Task enabled successfully.";
                        break;

                    case "disable":
                        targetTask.Enabled = false;
                        message = "Task disabled successfully.";
                        break;

                    default:
                        return new ChangeTaskStatusResponse
                        {
                            TaskName = request.TaskName,
                            Status = "invalid",
                            Message = $"Invalid status '{request.Status}'. Allowed values are 'run', 'end', 'enable', 'disable'."
                        };
                }

                return new ChangeTaskStatusResponse
                {
                    TaskName = request.TaskName,
                    Status = request.Status,
                    Message = message
                };
            }
        }
    }
}

