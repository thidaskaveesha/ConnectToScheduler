namespace backend.Models
{
    public class ChangeTaskStateRequest
    {
        public string TaskName { get; set; }
        public string Status { get; set; } // "run", "end", "enable", "disable"
    }


}
