namespace WakuWakuAPI.Domain.Models;

public class Skill : BaseModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public ICollection<Goal> Goals { get; set; }
}
