using SportsAppDavidNicholOOP.Models.Interfaces;
using SportsAppDavidNicholOOP.Models.Sports;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsAppDavidNicholOOP.Models
{
    public class MatchResult : IMatchResult
    {
        public IMatch Match { get; set; }

        public string MatchResultOutputString { get; set; } // public for testing purposes

        public int randEventSeed; // this is also for testing purposes

        public MatchResult(IMatch match)
        {
            this.Match = match;
            this.MatchResultOutputString = "";
        }

        public string PrintMatchEvents(int forcedSeed, int forcedTeam, int forcedPlayer, int amountOfTimes) // forced variables are for testing only
        {
            Random randNumEvents = new Random();
            int amountOfEvents = randNumEvents.Next(10, 36); // a random amount of times events will occur

            this.MatchResultOutputString = ""; // reset output string

            if (Match.SportPlayed.GetType() == typeof(Football))
            {
                Football football = new Football();
                Random randEvent = new Random();

                for (int i = 0; i < amountOfTimes; i++)
                {
                    randEventSeed = randEvent.Next(0, Match.SportPlayed.NumEvents);

                    randEventSeed = forcedSeed; // this is for testing, will remove later

                    if (randEventSeed == 0)
                    {
                        MatchResultOutputString += football.Touchdown(Match.getRandomTeam(forcedTeam).GetRandomPlayer(forcedPlayer));
                    }
                    else if (randEventSeed == 1)
                    {
                        MatchResultOutputString += football.FieldGoal(Match.getRandomTeam(forcedTeam).GetRandomPlayer(forcedPlayer));
                    }
                    else if (randEventSeed == 2)
                    {
                        MatchResultOutputString += football.Interception(Match.getRandomTeam(forcedTeam).GetRandomPlayer(forcedPlayer));
                    }
                    else if (randEventSeed == 3)
                    {
                        MatchResultOutputString += football.Penalty(Match.getRandomTeam(forcedTeam).GetRandomPlayer(forcedPlayer));
                    }
                }
            }
            else if (Match.SportPlayed.GetType() == typeof(Baseball))
            {
                Baseball baseball = new Baseball();
                Random randEvent = new Random();
                randEvent.Next(0, Match.SportPlayed.NumEvents + 1);

                for (int i = 0; i < amountOfTimes; i++)
                {
                    randEventSeed = randEvent.Next(0, Match.SportPlayed.NumEvents);

                    randEventSeed = forcedSeed; // this is for testing, will remove later

                    if (randEventSeed == 0)
                    {
                        MatchResultOutputString += baseball.HomeRun(Match.getRandomTeam(forcedTeam).GetRandomPlayer(forcedPlayer));
                    }
                    else if (randEventSeed == 1)
                    {
                        MatchResultOutputString += baseball.GrandSlam(Match.getRandomTeam(forcedTeam).GetRandomPlayer(forcedPlayer));
                    }
                    else if (randEventSeed == 2)
                    {
                        MatchResultOutputString += baseball.ScoreRun(Match.getRandomTeam(forcedTeam).GetRandomPlayer(forcedPlayer));
                    }
                }
            }
            else if (Match.SportPlayed.GetType() == typeof(Hockey))
            {
                Hockey hockey = new Hockey();
                Random randEvent = new Random();
                randEvent.Next(0, Match.SportPlayed.NumEvents + 1);
                for (int i = 0; i < amountOfTimes; i++)
                {
                    randEventSeed = randEvent.Next(0, Match.SportPlayed.NumEvents);

                    randEventSeed = forcedSeed; // this is for testing, will remove later

                    if (randEventSeed == 0)
                    {
                        MatchResultOutputString += hockey.Fight(Match.getRandomTeam(forcedTeam).GetRandomPlayer(forcedPlayer));
                    }
                    else if (randEventSeed == 1)
                    {
                        MatchResultOutputString += hockey.StealPuck(Match.getRandomTeam(forcedTeam).GetRandomPlayer(forcedPlayer));
                    }
                    else if (randEventSeed == 2)
                    {
                        MatchResultOutputString += hockey.Score(Match.getRandomTeam(forcedTeam).GetRandomPlayer(forcedPlayer));
                    }
                }
            }
            else if (Match.SportPlayed.GetType() == typeof(Basketball))
            {
                Basketball basketBall = new Basketball();
                Random randEvent = new Random();
                randEvent.Next(0, Match.SportPlayed.NumEvents + 1);
                // amount of times should be amount of events

                for (int i = 0; i < amountOfTimes; i++)
                {
                    randEventSeed = randEvent.Next(0, Match.SportPlayed.NumEvents);

                    randEventSeed = forcedSeed; // this is for testing, will remove later

                    if (randEventSeed == 0)
                    {
                        MatchResultOutputString += basketBall.ThreePoint(Match.getRandomTeam(forcedTeam).GetRandomPlayer(forcedPlayer));
                    }
                    else if (randEventSeed == 1)
                    {
                        MatchResultOutputString += basketBall.TwoPoint(Match.getRandomTeam(forcedTeam).GetRandomPlayer(forcedPlayer));
                    }
                    else if (randEventSeed == 2)
                    {
                        MatchResultOutputString += basketBall.Foul(Match.getRandomTeam(forcedTeam).GetRandomPlayer(forcedPlayer));
                    }
                    else if (randEventSeed == 3)
                    {
                        MatchResultOutputString += basketBall.Dunk(Match.getRandomTeam(forcedTeam).GetRandomPlayer(forcedPlayer));
                    }

                }
            }
            return MatchResultOutputString;
        }

        public string DeclareWinner()
        {
            if (Match.Winner == null)
            {
                return DeclareTie();
            }

            return $"This exciting {Match.TeamOne.Name} vs. {Match.TeamTwo.Name} match on {Match.Date} resulted in a {Match.Winner.Name} Victory.";
        }

        public string DeclareTie()
        {
            return $"This exciting {Match.TeamOne.Name} vs. {Match.TeamTwo.Name} match on {Match.Date} resulted in a draw.";
        }
    }
}
