using Microsoft.AspNetCore.Mvc;
using TrueVote.Web.Services.Interfaces;

namespace TrueVote.Web.Controllers;

public sealed class VotesController(ISubmitVoteService submitVoteService) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    /// Submits a new vote for a VoteOption
    /// </summary>
    /// <param name="voteOption">Survey ID</param>
    [HttpPost]
    [Route("/Votes/Submit/{voteOption}")]
    public async Task<IActionResult> Submit([FromRoute] int voteOption)
    {
        await submitVoteService.CreateAsync(voteOption);
        return Accepted();
    }
}