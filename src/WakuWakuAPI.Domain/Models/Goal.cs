namespace WakuWakuAPI.Domain.Models;
public class Goal {
    private static int lastId = 0;
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime DateOfCreation { get; set; }
    public DateTime Deadline { get; set; }
    public String Status { get; set; }

    public Goal(string description, DateTime dateOfCreation, DateTime deadline, string status) {
        this.Id = ++lastId;
        this.Description = description;
        this.DateOfCreation = dateOfCreation;
        this.Deadline = deadline;
        this.Status = status;
    }
}
