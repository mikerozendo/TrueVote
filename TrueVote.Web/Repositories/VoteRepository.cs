using Microsoft.EntityFrameworkCore;
using TrueVote.Web.Entities;
using TrueVote.Web.Repositories.Interfaces;

namespace TrueVote.Web.Repositories;

public class VoteRepository(ApplicationDbContext context) : IVoteRepository
{
    public async Task UpdateAsync(VoteOption voteOption)
    {
        context.VoteOptions.Update(voteOption);
        await context.SaveChangesAsync();
    }

    public async Task<VoteOption> GetBySurveyIdAsync(Guid surveyId)
    {
        return await context.VoteOptions.SingleAsync(x => x.SurveyId == surveyId);
    }
}