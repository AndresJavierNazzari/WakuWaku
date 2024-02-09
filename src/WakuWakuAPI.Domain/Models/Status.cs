namespace WakuWakuAPI.Domain.Models;

public class Status : BaseModel
{
    public String Description { get; set; }
    public ICollection<Goal> Goals { get; set; }
}
