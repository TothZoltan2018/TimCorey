namespace TrackerLibrary
{
    public class MatchupEntryModel
    {
        /// <summary>
        /// Represents  one team in the matchup
        /// </summary>
        public TeamModel TeeamCompeting { get; set; }
        public double Score { get; set; }
        /// <summary>
        /// Represents the matchup  that this team came from as the winner
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }
    }
}