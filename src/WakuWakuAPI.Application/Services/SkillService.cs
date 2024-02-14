using MapsterMapper;

using WakuWakuAPI.Domain.Models;
using WakuWakuAPI.Domain.DTOs;
using WakuWakuAPI.Application.Services.Interfaces;
using WakuWakuAPI.Infraestructure.Repositories.Interfaces;
using WakuWakuAPI.Application.CrossCutting;
using WakuWakuAPI.Application.Consts;
using WakuWakuAPI.Infraestructure.Repositories;

namespace WakuWakuAPI.Application.Services;

public class SkillService : ISkillService
{
    private readonly ISkillRepository _skillRepository;
    private readonly IMapper _mapper;

    public SkillService(ISkillRepository skillRepository, IMapper mapper)
    {
        ArgumentNullException.ThrowIfNull(skillRepository);
        ArgumentNullException.ThrowIfNull(mapper);
        _skillRepository = skillRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Skill>> GetSkillsAsyncAsNoTracking()
    {
        var skillsList = await _skillRepository.GetSkillsAsyncAsNoTracking();
        NotFoundException.ThrowIfNull(skillsList, ErrorMessage.CategoryListEmpty);

        return skillsList!;
    }

    public async Task<Skill?> GetSkillByIdAsyncAsNoTracking(int id)
    {
        var skill = await _skillRepository.GetSkillByIdAsyncAsNoTracking(id);
        NotFoundException.ThrowIfNull(skill, $"{ErrorMessage.SkillIdNotFound} {id}");

        return skill;
    }

    public async Task<Skill?> GetSkillByIdAsync(int id)
    {
        var skill = await _skillRepository.GetSkillByIdAsync(id);
        NotFoundException.ThrowIfNull(skill, $"{ErrorMessage.SkillIdNotFound} {id}");

        return skill;
    }

    public async Task<Skill> AddSkillAsync(SkillForCreation skillForCreation)
    {
        ArgumentNullException.ThrowIfNull(skillForCreation);
        var skill = _mapper.Map<Skill>(skillForCreation);
        await _skillRepository.AddSkillAsync(skill);

        return skill;
    }

    public async Task<Skill> UpdateSkillAsync(SkillForUpdate skillForUpdate)
    {
        var newValuesSkill = _mapper.Map<Skill>(skillForUpdate);
        var categoryToUpdate = await GetSkillByIdAsync(newValuesSkill.Id);
        NotFoundException.ThrowIfNull(categoryToUpdate, $"{ErrorMessage.SkillIdNotFound} {newValuesSkill.Id}");
        var updatedSkill = await _skillRepository.UpdateSkillAsync(categoryToUpdate!, newValuesSkill);

        return updatedSkill;
    }

    public async Task<Skill> DeleteSkillByIdAsync(int id)
    {

        var skill = await _skillRepository.GetSkillByIdAsync(id);
        NotFoundException.ThrowIfNull(skill, $"{ErrorMessage.SkillIdNotFound} {id}");

        await _skillRepository.DeleteSkillByIdAsync(skill!);
        return skill!;
    }
}
