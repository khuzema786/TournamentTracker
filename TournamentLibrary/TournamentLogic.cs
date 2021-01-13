using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentLibrary.Models;

namespace TournamentLibrary
{
    public static class TournamentLogic
    {
        // Order our lists randomly of teams
        // Check if the list is big enough - If not, add in byes - 2*2*2*2...2^n
        // Create our first round of matchups
        // Create every round after that eg: 8 matchups - 4 matchups - 2 matchups - 1 matchup i.e, Matchups divide by 2 Each time

        public static void CreateRounds(TournamentModel model)
        {
            List<TeamModel> randomizedTeams = RandomizeTeamOrder(model.EnteredTeams);
            int rounds = FindNumberOfRounds(randomizedTeams.Count);
            int byes = NumberOfByes(rounds, randomizedTeams.Count);

            // All byes meaning the matchups with just one team going straight to next round without 
            // competing with any other team, those byes are all taken care of in the First round itself
            model.Rounds.Add(CreateFirstRound(byes, randomizedTeams));

            CreateOtherRounds(model, rounds);
        }
        private static void CreateOtherRounds(TournamentModel model, int rounds)
        {
            int round = 2; // First round is created already
            List<MatchupModel> previousRound = model.Rounds[0]; // Round 1 matchups
            List<MatchupModel> currRound = new List<MatchupModel>();
            MatchupModel currMatchup = new MatchupModel();

            while(round <= rounds)
            {
                foreach (MatchupModel match in previousRound)
                {
                    currMatchup.Entries.Add(new MatchupEntryModel { ParentMatchup = match });

                    if(currMatchup.Entries.Count > 1) // If two teams, then a matchup can be formed
                    {
                        currMatchup.MatchupRound = round;
                        currRound.Add(currMatchup);
                        currMatchup = new MatchupModel(); // Reset the instance of currMatchup to account for different matchups
                    }
                }
                // Add all the matchups for current round and go to the next round till the matchups for all rounds are completed
                model.Rounds.Add(currRound);
                previousRound = currRound; // Current round becomes previous round for the next round

                currRound = new List<MatchupModel>(); // Reset the instance of currRound to account for the next set of rounds
                round++;
            }

        }
        private static List<MatchupModel> CreateFirstRound(int byes, List<TeamModel> teams)
        {
            List<MatchupModel> output = new List<MatchupModel>();
            MatchupModel curr = new MatchupModel();

            foreach (TeamModel team in teams)
            {
                curr.Entries.Add(new MatchupEntryModel { TeamCompeting = team });

                if(byes > 0 || curr.Entries.Count > 1)
                {                    
                    curr.MatchupRound = 1; // First round created
                    output.Add(curr);
                    curr = new MatchupModel(); // Refresh curr MatchUp model to add next two teams for Round 1 till all teams are over

                    if(byes > 0)
                    {
                        byes -= 1;
                    }
                }
            }

            return output;
        }
        private static int NumberOfByes(int rounds, int teamCount)
        {
            int output = 0;
            int totalTeams = 1;

            for (int i = 1; i <= rounds; i++)
            {
                totalTeams *= 2;
            }

            output = totalTeams - teamCount;

            return output;
        }
        private static int FindNumberOfRounds(int teamCount)
        {
            int output = 1;
            int val = 2;

            while(val < teamCount)
            {
                output += 1;
                val *= 2;
            }

            return output;
        }
        private static List<TeamModel> RandomizeTeamOrder(List<TeamModel> teams)
        {
            return teams.OrderBy(x => Guid.NewGuid()).ToList(); // Guid assigns new id to elements of lists and randomizes it while sorting
        }
    }
}
