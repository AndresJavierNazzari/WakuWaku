namespace WakuWakuAPI.Domain.Models;

public class Dificulty : BaseModel
{
    public string Description { get; set; }
    public ICollection<Goal> Goals { get; set; }
}
