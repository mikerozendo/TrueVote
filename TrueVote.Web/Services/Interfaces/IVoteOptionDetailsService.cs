using TrueVote.Web.Entities;

namespace TrueVote.Web.Services.Interfaces;

public interface IVoteOptionDetailsService
{
    Task<IEnumerable<VoteOptionDetails>> GetAsync();
}