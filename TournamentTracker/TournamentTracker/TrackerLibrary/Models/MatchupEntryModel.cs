using System.Data;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// Represents one team in a matchup
    /// </summary>
    public class MatchupEntryModel
    {
        public int Id { get; set; }

        /// <summary>
        /// The unique indentifier for the team.
        /// </summary>
        public int TeamCompetingId { get; set; }

        /// <summary>
        /// Represents one team in the matchup
        /// </summary>
        public TeamModel TeamCompeting { get; set; }

        public double Score { get; set; }

        /// <summary>
        /// The unique indentifier for the parent matchup (team).
        /// </summary>
        public int ParentMatchupId { get; set; }
        /// <summary>
        /// Represents the matchup  that this team came from as the winner
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }
    }
}