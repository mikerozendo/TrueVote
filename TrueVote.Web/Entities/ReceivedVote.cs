namespace TrueVote.Web.Entities;

public class ReceivedVote(Guid id, Guid voteOptionDetailsId)
{
    public Guid Id { get; init; } = id;
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public VoteOptionDetails VoteOptionDetails { get; init; }
    public Guid VoteOptionDetailsId { get; set; } = voteOptionDetailsId;
}