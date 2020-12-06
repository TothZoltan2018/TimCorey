using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class TournamentModel
    {
        public event EventHandler<DateTime> OnTournamentComplete;

        public int Id { get; set; }
        public string TournamentName { get; set; }
        public decimal EntryFee { get; set; }
        public List<TeamModel> EnteredTeams { get; set; } = new List<TeamModel>();
        public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();
        /// <summary>
        /// In each round there can be several matchups
        /// </summary>
        public List<List<MatchupModel>> Rounds { get; set; } = new List<List<MatchupModel>>();

        // This method fires the OnTournamentComplete event
        public void CompleteTournament()
        {
            // "?" This is a newer c# feature. Checks for subscribers. If there are some, then event can be fired
            OnTournamentComplete?.Invoke(this, DateTime.Now); // This jumps to the eventhandler, that is Tournament_OnTournamentComplete(object sender, DateTime e)
        }
    }
}
