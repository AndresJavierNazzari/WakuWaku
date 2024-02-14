namespace WakuWakuAPI.Domain.DTOs;

public class SkillForUpdate
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int? CategoryId { get; set; }
}
