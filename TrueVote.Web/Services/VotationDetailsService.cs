using TrueVote.Web.Entities;
using TrueVote.Web.Repositories.Interfaces;
using TrueVote.Web.Services.Interfaces;

namespace TrueVote.Web.Services;

public class VotationDetailsService(IVoteRepository voteRepository) : IVotationDetailsService
{
    public async Task<IEnumerable<VoteReportByOption>> GetAsync()
    {
        var receivedVotes = await voteRepository.GetVotesAsync();
        if (receivedVotes.Count == 0)
            return [];

        var groupedVotesByOption = receivedVotes.GroupBy(x => x.OptionKey).ToList();
        if (groupedVotesByOption.Count == 0)
            return [];

        return groupedVotesByOption.Select(
            x =>
                new VoteReportByOption(x,
                    groupedVotesByOption.Count(y => y.Key != x.Key)));
    }
}