namespace TrackerLibrary.Models
{
    /// <summary>
    /// Represents one team in a matchup
    /// </summary>
    public class MatchupEntryModel
    {
        /// <summary>
        /// Represents one team in the matchup
        /// </summary>
        public TeamModel TeamCompeting { get; set; }

        public double Score { get; set; }

        /// <summary>
        /// Represents the matchup  that this team came from as the winner
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }
    }
}