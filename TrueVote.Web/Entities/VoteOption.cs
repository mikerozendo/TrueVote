namespace TrueVote.Web.Entities;

public sealed class VoteOption
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public string FilePath { get; set; }
    public int ReceivedVotes { get; set; }
}