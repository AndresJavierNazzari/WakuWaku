using WakuWakuAPI.Domain.Models;
using WakuWakuAPI.Domain.DTOs;

namespace WakuWakuAPI.Infraestructure.Repositories.Interfaces;
public interface IGoalRepository {
    IEnumerable<Goal> GetGoals();
    Goal GetGoalById(int id);
    Goal AddGoal(GoalForCreation goalForCreation);
    Goal UpdateGoal(int id, GoalForUpdate goalForUpdate);
    Goal DeleteGoalById(int id);
}