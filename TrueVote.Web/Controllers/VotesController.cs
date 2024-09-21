using Microsoft.AspNetCore.Mvc;
using TrueVote.Web.Services.Interfaces;

namespace TrueVote.Web.Controllers;

public sealed class VotesController(ISubmitVoteService submitVoteService) : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    /// Submits a new vote for a VoteOption
    /// </summary>
    /// <param name="surveyId">Survey ID</param>
    [HttpPatch]
    [Route("/Votes/Submit/{surveyId}")]
    public async Task<IActionResult> Submit([FromRoute] Guid surveyId)
    {
        await submitVoteService.SubmitAsync(surveyId);
        return Accepted();
    }
}