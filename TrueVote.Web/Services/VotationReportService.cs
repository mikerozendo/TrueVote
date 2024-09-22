using TrueVote.Web.Entities;
using TrueVote.Web.Repositories.Interfaces;
using TrueVote.Web.Services.Interfaces;

namespace TrueVote.Web.Services;

public class VotationReportService(IReceivedVotesRepository receivedVotesRepository) : Interfaces.IVotationReportService
{
    public async Task<IEnumerable<VoteReportByOption>> GetAsync()
    {
        var receivedVotes = await receivedVotesRepository.GetVotesAsync();
        if (receivedVotes.Count == 0)
            return [];

        var groupedVotesByOption = receivedVotes.GroupBy(x => x.VoteOptionDetailsId).ToList();
        if (groupedVotesByOption.Count == 0)
            return [];

        return groupedVotesByOption.Select(
            x =>
                new VoteReportByOption(x,
                    groupedVotesByOption.Count(y => y.Key != x.Key)));
    }
}