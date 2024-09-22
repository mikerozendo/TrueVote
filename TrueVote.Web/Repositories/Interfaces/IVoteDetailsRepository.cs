using TrueVote.Web.Entities;

namespace TrueVote.Web.Repositories.Interfaces;

public interface IVoteOptionsDetailsRepository
{
    Task<VoteOptionDetails> GetByOptionKeyAsync(int optionKey);
    Task<IEnumerable<VoteOptionDetails>> GetAsync();
}