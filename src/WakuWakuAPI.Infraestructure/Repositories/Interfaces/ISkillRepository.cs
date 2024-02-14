using WakuWakuAPI.Domain.Models;
using WakuWakuAPI.Domain.DTOs;

namespace WakuWakuAPI.Infraestructure.Repositories.Interfaces;

public interface ISkillRepository
{
    Task<IEnumerable<Skill>?> GetSkillsAsyncAsNoTracking();
    Task<Skill?> GetSkillByIdAsyncAsNoTracking(int id);
    Task<Skill?> GetSkillByIdAsync(int id);
    Task<Skill> AddSkillAsync(Skill skill);
    Task<Skill> UpdateSkillAsync(Skill skillToUpdate, Skill newValuesSkill);
    Task<Skill> DeleteSkillByIdAsync(Skill skill);
}
