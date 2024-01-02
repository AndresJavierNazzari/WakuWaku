
using WakuWakuAPI.Domain.Models;
using WakuWakuAPI.Domain.DTOs;
using WakuWakuAPI.Infraestructure.Repositories.Interfaces;
using WakuWakuAPI.Application.Services.Interfaces;

namespace WakuWakuAPI.Application.Services;
public class GoalService : IGoalService {
    private readonly IGoalRepository _goalRepository;

    public GoalService(IGoalRepository goalRepository) {
        _goalRepository = goalRepository;
    }

    public IEnumerable<Goal> GetGoals(int page, int pageSize, string filter) {
        var goalList = _goalRepository.GetGoals();
        var paginatedGoals = goalList.Skip((page - 1) * pageSize).Take(pageSize);

        if(!string.IsNullOrEmpty(filter)) {
            paginatedGoals =
                paginatedGoals.Where(c => c.Description.Contains(filter, StringComparison.OrdinalIgnoreCase));
        }

        return paginatedGoals;
    }

    public Goal GetGoalById(int id) {
        Goal goal = _goalRepository.GetGoalById(id);

        return goal;
    }

    public Goal AddGoal(GoalForCreation goalForCreation) {
        Goal createdGoal = _goalRepository.AddGoal(goalForCreation);

        return createdGoal;
    }

    public Goal UpdateGoal(int id, GoalForUpdate goalForUpdate) {
        Goal updatedGoal = _goalRepository.UpdateGoal(id, goalForUpdate);

        return updatedGoal;
    }

    public Goal DeleteGoalById(int id) {
        Goal goal = _goalRepository.DeleteGoalById(id);
        //NotFoundException.ThrowIfNull(goal);

        return goal;
    }
}
