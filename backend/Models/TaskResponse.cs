namespace backend.Models
{
    public class TaskResponse
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime? NextRunTime { get; set; }
        public DateTime? LastRunTime { get; set; }
    }
}
