using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace TrueVote.Web.Entities;

public sealed class Survey(Guid id, string description, IEnumerable<VoteOption> voteOptions)
{
    public Guid Id { get; set; } = id;
    public string Description { get; set; } = description;
    public IEnumerable<VoteOption> VoteOptions { get; } = voteOptions;
    public DateTime? ExpirationDate { get; private set; }

    public void SetExpirationDate(DateTime expirationDate)
    {
        ExpirationDate = expirationDate;    
    }
}


