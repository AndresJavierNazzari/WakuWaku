using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using FluentValidation;
using FluentValidation.Results;
using WakuWakuAPI.Domain.Models;
using WakuWakuAPI.Domain.DTOs;
using WakuWakuAPI.Application.Consts;
using WakuWakuAPI.Application.CrossCutting;
using WakuWakuAPI.Application.Services.Interfaces;

namespace WakuWakuAPI.Presentation.Controllers;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
public class SkillController : ControllerBase
{
    private readonly ISkillService _skillService;

    public SkillController(ISkillService skillService)
    {
        ArgumentNullException.ThrowIfNull(skillService);
        _skillService = skillService;
    }

    // GET: /skill
    [HttpGet]
    [HttpHead]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<Skill>>> GetSkillsAsyncAsNoTracking()
    {
        var skillsList = await _skillService.GetSkillsAsyncAsNoTracking();
        return Ok(skillsList);
    }

    // GET: /skill/{skillId}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Skill>> GetSkillByIdAsyncAsNoTracking(int id)
    {
        EmptyIdException.ThrowIfIdZero(id, ErrorMessage.IdZeroOrNegative);
        var skill = await _skillService.GetSkillByIdAsyncAsNoTracking(id);
        return Ok(skill);
    }

    // POST: /skill
    [HttpPost(Name = "CreateSkill")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<Skill>> AddSkillAsync(SkillForCreation skillForCreation)
    {
        //add validations
        ArgumentNullException.ThrowIfNull(skillForCreation);
        var skill = await _skillService.AddSkillAsync(skillForCreation);
        return CreatedAtRoute("CreateSkill", skill);
    }

    //  PUT: /skill
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Skill>> UpdateSkillAsync([FromBody] SkillForUpdate skillForUpdate)
    {
        ArgumentNullException.ThrowIfNull(skillForUpdate);
        var skill = await _skillService.UpdateSkillAsync(skillForUpdate);
        return Ok(skill);
    }

    // DELETE: /skill/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Skill>> DeleteSkillByIdAsync(int id)
    {
        EmptyIdException.ThrowIfIdZero(id, ErrorMessage.IdZeroOrNegative);
        var skill = await _skillService.DeleteSkillByIdAsync(id);
        var response = new { message = $"Skill with id {id} was deleted", skill };

        return Ok(response);
    }

    // OPTIONS: /skill
    [HttpOptions]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetSkillsOptions()
    {
        Response.Headers.Append("Allow", "GET, POST, PUT, DELETE, OPTIONS");
        return Ok();
    }
}
