namespace WakuWakuAPI.Domain.Models;

public class Category : BaseModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Skill> Skills { get; set; }
}
