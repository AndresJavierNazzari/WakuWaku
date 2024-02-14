using Microsoft.EntityFrameworkCore;

using WakuWakuAPI.Domain.Models;
using WakuWakuAPI.Infraestructure.Data;
using WakuWakuAPI.Infraestructure.Repositories.Interfaces;

namespace WakuWakuAPI.Infraestructure.Repositories;

public class SkillRepository : ISkillRepository
{
    private readonly WakuWakuContext _context;

    public SkillRepository(WakuWakuContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        _context = context;
    }

    public async Task<IEnumerable<Skill>?> GetSkillsAsyncAsNoTracking()
    {
        /* 
        var skillsWithCategories = await _context.Skills
               .Include(skill => skill.Category)
               .AsNoTracking()
               .ToListAsync();

        return skillsWithCategories;
        */

        var skillsTask = await Task.FromResult(_context.Skills.AsNoTracking().ToListAsync());
        return skillsTask.Result;
    }

    public async Task<Skill?> GetSkillByIdAsyncAsNoTracking(int id)
    {
        return await _context.Skills.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Skill?> GetSkillByIdAsync(int id)
    {
        return await _context.Skills.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Skill> AddSkillAsync(Skill skill)
    {
        await _context.Skills.AddAsync(skill);
        await _context.SaveChangesAsync();
        return skill;
    }

    public async Task<Skill> UpdateSkillAsync(Skill skillToUpdate, Skill newValuesSkill)
    {
        // Save the value of CreatedAt from the original entity
        var createdAt = skillToUpdate.CreatedAt;

        // Copy the values from the new entity to the original entity
        _context.Entry(skillToUpdate).CurrentValues.SetValues(newValuesSkill);

        // Restore the value of CreatedAt
        skillToUpdate.CreatedAt = createdAt;

        // Set the state of the entity as modified
        _context.Entry(skillToUpdate).State = EntityState.Modified;

        // Save the changes
        await _context.SaveChangesAsync();

        // Return the updated entity
        return skillToUpdate;
    }

    public async Task<Skill> DeleteSkillByIdAsync(Skill skill)
    {
        _context.Entry(skill).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return skill;
    }
}
