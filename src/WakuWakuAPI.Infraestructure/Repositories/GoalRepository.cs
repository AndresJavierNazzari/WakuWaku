using WakuWakuAPI.Domain.Models;
using WakuWakuAPI.Domain.DTOs;
using WakuWakuAPI.Infraestructure.Repositories.Interfaces;
using WakuWakuAPI.Infraestructure.Data;

namespace WakuWakuAPI.Infraestructure.Repositories;
public class GoalRepository : IGoalRepository
{
    private readonly WakuWakuContext _context;
    public GoalRepository(WakuWakuContext context)
    {
        //ArgumentNullException.ThrowIfNull(context);
        _context = context;
    }
    public IEnumerable<Goal> GetGoals()
    {
        var goalsList = _context.Goals ?? throw new Exception();
        //NotFoundException.ThrowIfNull(goalsList);

        return goalsList;
    }

    public Goal GetGoalById(int id)
    {
        var goalsList = _context.Goals;

        Goal? goal = goalsList.FirstOrDefault(g => g.Id == id);

        //NotFoundException.ThrowIfNull(goal);

        return goal;
    }
    public Goal AddGoal(GoalForCreation goalForCreation)
    {
        var goalsList = _context.Goals;

        // Goal createdGoal = new Goal(goalForCreation.Description, goalForCreation.DateOfCreation, goalForCreation.Deadline, goalForCreation.Status);

        //goalsList.Add(createdGoal);
        return null;
        //return createdGoal;
    }
    public Goal UpdateGoal(int id, GoalForUpdate goalForUpdate)
    {
        var goalsList = _context.Goals;
        Goal? existingGoal = goalsList.FirstOrDefault(g => g.Id == id);
        //NotFoundException.ThrowIfNull(existingGoal);
        return null;
        /*
        existingGoal.Description = goalForUpdate.Description;
        existingGoal.DateOfCreation = goalForUpdate.DateOfCreation;
        existingGoal.Deadline = goalForUpdate.Deadline;
        existingGoal.Status = goalForUpdate.Status;

        return existingGoal;
        */
    }
    public Goal DeleteGoalById(int id)
    {
        var goalsList = _context.Goals;
        Goal? deletedGoal = goalsList.FirstOrDefault(g => g.Id == id);

        //NotFoundException.ThrowIfNull(deletedGoal);
        goalsList.Remove(deletedGoal);

        return deletedGoal;
    }
}
