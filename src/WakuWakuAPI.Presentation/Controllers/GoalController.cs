using Microsoft.AspNetCore.Mvc;
using WakuWakuAPI.Domain.Models;
using WakuWakuAPI.Domain.DTOs;
using WakuWakuAPI.Application.Services.Interfaces;
using Asp.Versioning;
using System.ComponentModel.DataAnnotations;

namespace WakuWakuAPI.Presentation.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class GoalController : ControllerBase {
    private readonly IGoalService _goalService;

    public GoalController(IGoalService goalService) {
        _goalService = goalService;
    }

    // GET: /Goal
    [HttpGet]
    [HttpHead]
    public ActionResult<IEnumerable<Goal>> GetGoals([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string filter = "") {
        var goals = _goalService.GetGoals(page, pageSize, filter);
        return Ok(goals);
    }

    [HttpGet("{id}")]
    public ActionResult<Goal> GetGoalById(int id) {
        Goal goal = _goalService.GetGoalById(id);

        return Ok(goal);
    }

    // POST: /Goal
    [HttpPost(Name = "CreateGoal")]
    public ActionResult<Goal> CreateGoal([FromBody] GoalForCreation goalForCreation) {

        Goal goal = _goalService.AddGoal(goalForCreation);

        return CreatedAtRoute("CreateGoal", new { id = goal.Id }, goal);
    }

    //  PUT: /Goal/{id}
    [HttpPut("{id}")]
    public ActionResult<Goal> UpdateGoal(int id, [FromBody] GoalForUpdate goalForUpdate) {
        Goal goal = _goalService.UpdateGoal(id, goalForUpdate);

        return Ok(goal);
    }

    // DELETE:/Goal/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteGoal(int id) {
        var deletedGoal = _goalService.DeleteGoalById(id);

        var response = new {
            message = $"Resource deleted: goal {id}",
            deletedGoal
        };

        return Ok(response);
    }

    // OPTIONS: /Goal
    [HttpOptions]
    public IActionResult OptionsGoal() {
        Response.Headers.Append("Allow", "GET, POST, PUT, DELETE, OPTIONS, HEAD");
        return Ok();
    }

}
