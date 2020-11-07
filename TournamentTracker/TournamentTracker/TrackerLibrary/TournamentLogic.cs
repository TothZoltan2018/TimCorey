using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public static class TournamentLogic
    {
        // Order our team list randomly
        // Check if it is big enough for the starting round. If not, add in byes.
        // (Byes is a dummy team just to complete the number of teams to the needed number.)
        // E.g. in case of 14 participants 2 byes teams needed. 2 pow n
        // Create our first round of machups
        // Create every round after that. In a round the number of machups is half of the one in the previous round.

        public static void CreateRounds(TournamentModel model)
        {
            List<TeamModel> randomizedTeams = RandomizeTeamOrder(model.EnteredTeams);
            int rounds = FindNumberOfRounds(randomizedTeams.Count);
            int byes = NumberOfByes(rounds, randomizedTeams.Count);

            model.Rounds.Add(CreateFirstRound(byes, randomizedTeams));
            
            CreateOtherRounds(model, rounds);
        }

        private static void CreateOtherRounds(TournamentModel model, int rounds)
        {
            int round = 2;
            List<MatchupModel> previousRound = model.Rounds[0]; // First round
            List<MatchupModel> currRound = new List<MatchupModel>();
            MatchupModel currMatchup = new MatchupModel();

            // round1       round2      round3
            // ----
            // match1       ----
            // ----
            //              match3       ----    
            // ----
            // match2       ----
            // ----

            while (round <= rounds)
            {
                // We create half as many matchups in the current round as in the previous one 
                foreach (MatchupModel match in previousRound)
                {
                    currMatchup.Entries.Add(new MatchupEntryModel { ParentMatchup = match });

                    // If both MatchupEntryModels are added for this matchup, then the matchup is ready to be added to the current round
                    if (currMatchup.Entries.Count > 1) 
                    {
                        currMatchup.MatchupRound = round;
                        currRound.Add(currMatchup);
                        currMatchup = new MatchupModel();
                    }
                }

                model.Rounds.Add(currRound);
                previousRound = currRound;

                currRound = new List<MatchupModel>();
                round++;
            }
        }

        // First round is special: It might have dummy teams (byes) to complete the num of teams to 2^n.
        private static List<MatchupModel> CreateFirstRound(int byes, List<TeamModel> teams)
        {
            List<MatchupModel> output = new List<MatchupModel>();
            MatchupModel curr = new MatchupModel();

            foreach (TeamModel team in teams)
            {
                curr.Entries.Add(new MatchupEntryModel { TeamCompeting = team });

                // If only one team is added yet and we have some byes then a bye will be added to the matchup (instead of a real team), no more teams needs to be added.
                // If there are already 2 teams then matchup is ready, no more teams needs to be added.
                if (byes > 0 || curr.Entries.Count > 1)
                {
                    curr.MatchupRound = 1;
                    output.Add(curr);
                    curr = new MatchupModel();

                    if (byes > 0)
                    {
                        byes--;
                    }
                }
            }

            return output;        
        }

        private static int MyFindNumberOfRounds(int teamCount)
        {
            int pow = 1;
            while (Math.Pow(2, pow) < teamCount)
            {
                pow++;
            }

            return pow;
        }

        private static int MyNumberOfByes(int rounds, int numberOfTeams)
        {
            return (int)Math.Pow(2, rounds) % numberOfTeams;
        }

        private static int FindNumberOfRounds(int teamCount)
        {
            int output = 1;
            int val = 2;

            while (val < teamCount )
            {
                output += 1;
                val *= 2;
            }

            return output;
        }

        private static int NumberOfByes(int rounds, int numberOfTeams)
        {
            int output = 0;
            int totalTeams = 1;

            for (int i = 1; i <= rounds; i++)
            {
                totalTeams *= 2;
            }

            output = totalTeams - numberOfTeams;

            return output;
        }

        private static List<TeamModel> RandomizeTeamOrder(List<TeamModel> teams)
        {
            return teams.OrderBy(x => Guid.NewGuid()).ToList(); // Orderby returns a NEW List.
        }
    }
}
