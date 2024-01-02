
using WakuWakuAPI.Domain.Models;
using WakuWakuAPI.Domain.DTOs;

namespace WakuWakuAPI.Application.Services.Interfaces;
public interface IGoalService {
    IEnumerable<Goal> GetGoals(int page, int pageSize, string filter);
    Goal GetGoalById(int id);
    Goal AddGoal(GoalForCreation goalForCreation);
    Goal UpdateGoal(int goalId, GoalForUpdate goalForUpdate);
    Goal DeleteGoalById(int id);
}
