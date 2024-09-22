using TrueVote.Web.Entities;

namespace TrueVote.Web.Services.Interfaces;

public interface IVotationReportService
{
    Task<IEnumerable<VoteReportByOption>> GetAsync();
}