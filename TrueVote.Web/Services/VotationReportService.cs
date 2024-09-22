using Microsoft.IdentityModel.Tokens;
using TrueVote.Web.Entities;
using TrueVote.Web.Repositories.Interfaces;
using TrueVote.Web.Services.Interfaces;

namespace TrueVote.Web.Services;

public class VotationReportService(
    IReceivedVotesRepository receivedVotesRepository,
    IVoteOptionsDetailsRepository voteOptionsDetailsRepository) : IVotationReportService
{
    public async Task<IEnumerable<VoteReportByOption>> GetAsync()
    {
        var voteOptions = await voteOptionsDetailsRepository.GetAsync();
        if (voteOptions.IsNullOrEmpty())
            return [];

        var receivedVotes = await receivedVotesRepository.GetVotesAsync();
        if (receivedVotes.IsNullOrEmpty())
            return [];

        var groupedVotesByOption = receivedVotes.GroupBy(x => x.VoteOptionDetailsId).ToList();
        if (groupedVotesByOption.IsNullOrEmpty())
            return [];

        var compositionToBeDetailed = voteOptions.Select(x =>
        {
            var groupedVotesToThisOption = groupedVotesByOption.Where(y => y.Key == x.Id).ToList().Count;
            return Tuple.Create(x, groupedVotesToThisOption);
        });


        return compositionToBeDetailed.Select(x =>
            new VoteReportByOption(x.Item1, x.Item2, receivedVotes.Count));
    }
}