// namespace TrueVote.Web.Entities;
//
// public class SurveyDetails(Survey survey)
// {
//     private readonly Survey? _survey = survey;
//
//     public int? TotalVotesFromALlOptions
//     {
//         get { return _survey?.VoteOptions.Sum(x => x.ReceivedVotes); }
//     }
//
//     public int? WinnerVotePercentage
//     {
//         get
//         {
//             if (CurrentWinner is null)
//                 return null;
//
//             var totalVotes = TotalVotesFromALlOptions!.Value;
//             return (CurrentWinner.ReceivedVotes * 100) / totalVotes;
//         }
//     }
//
//     public VoteOption? CurrentWinner
//     {
//         get { return _survey?.VoteOptions?.MaxBy(x => x.ReceivedVotes); }
//     }
// }