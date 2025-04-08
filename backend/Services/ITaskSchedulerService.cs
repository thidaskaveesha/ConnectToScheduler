using backend.Models;

namespace backend.Services
{
    public interface ITaskSchedulerService
    {
        List<TaskResponse> GetUserCreatedTasks();
        ChangeTaskStatusResponse ChangeTaskStatus(ChangeTaskStateRequest request);
    }
}
