namespace TrueVote.Web.Entities;

public class VoteReportByOption
{
    public int OptionKey { get; private set; }
    public int ReceivedVotesAmout { get; private set; }
    public int OtherCompetitorReceivedVotes { get; private set; }
    public int ReceivedVotesPercenteage { get; private set; }

    public VoteReportByOption(IGrouping<int, ReceivedVote> currentVoteOption, int otherCompetitorReceivedVotes)
    {
        OptionKey = currentVoteOption.Key;
        ReceivedVotesAmout = currentVoteOption.Count();
        OtherCompetitorReceivedVotes = otherCompetitorReceivedVotes;
        
        if (ReceivedVotesAmout > 0)
            ReceivedVotesPercenteage = (ReceivedVotesAmout * 100) / OtherCompetitorReceivedVotes;
    }
}