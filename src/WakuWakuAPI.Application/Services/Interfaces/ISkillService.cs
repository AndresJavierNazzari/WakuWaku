using WakuWakuAPI.Domain.DTOs;
using WakuWakuAPI.Domain.Models;

namespace WakuWakuAPI.Application.Services.Interfaces;

public interface ISkillService
{
    Task<IEnumerable<Skill>> GetSkillsAsyncAsNoTracking();
    Task<Skill?> GetSkillByIdAsyncAsNoTracking(int id);
    Task<Skill?> GetSkillByIdAsync(int id);
    Task<Skill> AddSkillAsync(SkillForCreation skillForCreation);
    Task<Skill> UpdateSkillAsync(SkillForUpdate skillForUpdate);
    Task<Skill> DeleteSkillByIdAsync(int id);
}
