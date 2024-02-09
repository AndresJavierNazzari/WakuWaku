namespace WakuWakuAPI.Domain.Models;
public class Goal : BaseModel
{
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int SkillId { get; set; }
    public Skill Skill { get; set; }
    public int DificultyId { get; set; }
    public Dificulty Dificulty { get; set; }
    public int StatusId { get; set; }
    public String Status { get; set; }
}
