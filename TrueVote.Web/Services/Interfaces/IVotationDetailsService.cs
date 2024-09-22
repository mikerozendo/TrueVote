using TrueVote.Web.Entities;

namespace TrueVote.Web.Services.Interfaces;

public interface IVotationDetailsService
{
    Task<IEnumerable<VoteReportByOption>> GetAsync();
}