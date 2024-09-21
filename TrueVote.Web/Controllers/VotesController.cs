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
    /// <param name="SurveyId">Survey ID</param>
    [HttpPatch]
    [Route("/Votes/{SurveyId}/Submit")]
    public async Task<IActionResult> Submit([FromRoute] Guid SurveyId)
    {
        await submitVoteService.SubmitAsync(SurveyId);
        return Accepted();
    }
}