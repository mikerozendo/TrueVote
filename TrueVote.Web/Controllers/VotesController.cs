using Microsoft.AspNetCore.Mvc;
using TrueVote.Web.Services.Interfaces;

namespace TrueVote.Web.Controllers;

public sealed class VotesController : Controller
{
    public async Task<IActionResult> Index([FromServices] IVotationDetailsService votationDetailsService) 
        => View(await votationDetailsService.GetAsync());
   
    public IActionResult Create() 
        => View();

    /// <summary>
    /// Submits a new vote for a VoteOption
    /// </summary>
    /// <param name="voteOption">Vote option</param>
    /// <param name="submitVoteService">Service to be called by DI</param>
    [HttpPost]
    [Route("/Votes/Submit/{voteOption}")]
    public async Task<IActionResult> Submit(
        [FromRoute] int voteOption, 
        [FromServices] ISubmitVoteService submitVoteService)
    {
        await submitVoteService.CreateAsync(voteOption);
        return Accepted();
    }
}