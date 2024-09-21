namespace TrueVote.Web.Entities;

public class VoteOption
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public string FilePath { get; set; }
    public int ReceivedVotes { get; set; }
    public Guid SurveyId { get; set; }
    public Survey Survey { get; set; }
}