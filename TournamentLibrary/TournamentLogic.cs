using System;
using System.Collections.Generic;
using System.Configuration;
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
        public static void UpdateTournamentResults(TournamentModel model)
        {
            int startingRound = model.CheckCurrentRound();
            List<MatchupModel> toScore = new List<MatchupModel>();

            foreach (List<MatchupModel> round in model.Rounds)
            {
                 foreach (MatchupModel rm in round)
                 {
                     if(rm.Winner == null &&  (rm.Entries.Any(x => x.Score != 0) || rm.Entries.Count == 1))
                    {
                        toScore.Add(rm);
                    }
                 }
            }

            MarkWinnerInMatchups(toScore);

            AdvanceWinners(toScore, model);

            toScore.ForEach(x => GlobalConfig.Connection.UpdateMatchup(x));
            int endingRound = model.CheckCurrentRound();

            if(endingRound > startingRound)
            {
                model.AlertUsersToNewRound();
            }
        }
        public static void AlertUsersToNewRound(this TournamentModel model)
        {
            int currentRoundNumber = model.CheckCurrentRound();
            List<MatchupModel> currentRound = model.Rounds.Where(x => x.First().MatchupRound == currentRoundNumber).First();

            foreach (MatchupModel matchup in currentRound)
            {
                foreach (MatchupEntryModel me in matchup.Entries)
                {
                    foreach (PersonModel p in me.TeamCompeting.TeamMembers)
                    {
                        AlertPersonToNewRound(p, me.TeamCompeting.TeamName, matchup.Entries.Where(x => x.TeamCompeting != me.TeamCompeting).FirstOrDefault());
                    }
                }
            }

        }
        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private static void AlertPersonToNewRound(PersonModel p, string teamName, MatchupEntryModel competitor)
        {
            if(!IsValidEmail(p.EmailAddress)) return;

            string to = "";
            string subject = "";
            // Helps in concatenating strings efficiently in terms of memory.
            StringBuilder body = new StringBuilder();

            if(competitor != null)
            {
                subject = $"You have a new matchup with { competitor.TeamCompeting.TeamName }.";

                body.AppendLine("<h1>You have a new matchup</h1>");
                body.Append("<strong>Competitor: </strong>");
                body.AppendLine(competitor.TeamCompeting.TeamName);
                body.AppendLine();
                body.AppendLine();
                body.AppendLine("Have a great time!");
                body.AppendLine("Tournament Tracker");
            }
            else
            {
                subject = $"You have a bye week for this round.";

                body.AppendLine("Enjoy your round off!");
                body.AppendLine();
                body.AppendLine();
                body.AppendLine("Tournament Tracker");
            }

            to = p.EmailAddress;

            EmailLogic.SendEmail(to, subject, body.ToString());
        }

        private static int CheckCurrentRound(this TournamentModel model)
        {
            int output = 1;

            foreach (List<MatchupModel> round in model.Rounds)
            {
                if(round.All(x => x.Winner != null))
                {
                    output++;
                }
                else
                {
                    return output;
                }
            }

            // Tournament completed
            CompleteTournament(model);

            return output - 1;
        }

        private static void CompleteTournament(TournamentModel model)
        {
            GlobalConfig.Connection.CompleteTournament(model);
            TeamModel winners = model.Rounds.Last().First().Winner;
            TeamModel runnerUp = model.Rounds.Last().First().Entries.Where(x => x.TeamCompeting != winners).First().TeamCompeting;

            decimal winnerPrize = 0;
            decimal runnerUpPrize = 0;

            if (model.Prizes.Count > 0)
            {
                decimal totalIncome = model.EnteredTeams.Count * model.EntryFee;

                PrizeModel firstPlacePrize = model.Prizes.Where(x => x.PlaceNumber == 1).FirstOrDefault();
                PrizeModel secondPlacePrize = model.Prizes.Where(x => x.PlaceNumber == 2).FirstOrDefault();

                if (firstPlacePrize != null)
                {
                    winnerPrize = firstPlacePrize.CalculatePrizePayout(totalIncome);
                }

                if (secondPlacePrize != null)
                {
                    runnerUpPrize = secondPlacePrize.CalculatePrizePayout(totalIncome);
                }
            }

            // Send Email to all tournament
            string subject = "";
            // Helps in concatenating strings efficiently in terms of memory.
            StringBuilder body = new StringBuilder();

            subject = $"In { model.TournamentName }, { winners.TeamName } has won!";

            body.AppendLine("<h1>We have a WINNER!</h1>");
            body.AppendLine("<p>Congratulations to our winner on a great tournament.</p>");
            body.AppendLine("<br/>");

            if(winnerPrize > 0)
            {
                body.AppendLine($"<p>{ winners.TeamName } will recieve { winnerPrize }</p>");
            }
            if (runnerUpPrize > 0)
            {
                body.AppendLine($"<p>{ runnerUp.TeamName } will recieve { runnerUpPrize }</p>");
            }

            body.AppendLine("<p>Thanks for a great tournament everyone!</P>");
            body.AppendLine("Tournament Tracker");

            List<string> bcc = new List<string>();

            foreach(TeamModel t in model.EnteredTeams)
            {
                foreach(PersonModel p in t.TeamMembers)
                {
                    if(p.EmailAddress.Length > 0)
                    {
                        bcc.Add(p.EmailAddress);
                    }
                }
            }

            EmailLogic.SendEmail(new List<string>(), bcc, subject, body.ToString());

            // Complete Tournament
            model.CompleteTournament();
        }
        private static decimal CalculatePrizePayout(this PrizeModel prize, decimal totalIncome)
        {
            decimal output = 0;

            if(prize.PrizeAmount > 0)
            {
                output = prize.PrizeAmount;
            }
            else
            {
                output = Decimal.Multiply(totalIncome, Convert.ToDecimal(prize.PrizePercentage / 100));
            }

            return output;
        }
        private static void AdvanceWinners(List<MatchupModel> models, TournamentModel tournament)
        {

            foreach (MatchupModel m in models)
            {
                foreach (List<MatchupModel> round in tournament.Rounds)
                {
                    foreach (MatchupModel rm in round)
                    {
                        foreach (MatchupEntryModel me in rm.Entries)
                        {
                            if (me.ParentMatchup != null)
                            {
                                if (me.ParentMatchup.Id == m.Id)
                                {
                                    me.TeamCompeting = m.Winner;
                                    GlobalConfig.Connection.UpdateMatchup(rm);
                                }
                            }
                        }
                    }
                } 
            }

        }
        private static void MarkWinnerInMatchups(List<MatchupModel> models)
        {
            // greater or lesser
            string greaterWins = ConfigurationManager.AppSettings["greaterWins"];

            // 0 means false or low score wins
            foreach (MatchupModel m in models)
            {
                // Check for bye week entry
                if(m.Entries.Count == 1)
                {
                    m.Winner = m.Entries[0].TeamCompeting;
                    continue;
                }

                if (greaterWins == "0")
                {
                    if (m.Entries[0].Score < m.Entries[1].Score)
                    {
                        // Team one wins
                        m.Winner = m.Entries[0].TeamCompeting;
                    }
                    else if (m.Entries[0].Score > m.Entries[1].Score)
                    {
                        // Team one wins
                        m.Winner = m.Entries[1].TeamCompeting;
                    }
                    else
                    {
                        throw new Exception("We do not allow ties in this application.");
                    }
                }
                // 1 means true or high score wins
                else 
                {
                    if (m.Entries[0].Score > m.Entries[1].Score)
                    {
                        // Team one wins
                        m.Winner = m.Entries[0].TeamCompeting;
                    }
                    else if (m.Entries[0].Score < m.Entries[1].Score)
                    {
                        // Team one wins
                        m.Winner = m.Entries[1].TeamCompeting;
                    }
                    else
                    {
                        throw new Exception("We do not allow ties in this application.");
                    }
                }
            }

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
