using SportsAppDavidNicholOOP.Models.Interfaces;
using SportsAppDavidNicholOOP.Models.Sports;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsAppDavidNicholOOP.Models
{
    [Serializable]
    public class MatchResult : IMatchResult
    {
        public IMatch Match { get; set; }

        public string MatchResultOutputString { get; set; } // public for testing purposes

        public MatchResult(IMatch match)
        {
            this.Match = match;
            this.MatchResultOutputString = "";
        }

        public string PrintMatchEvents() 
        {
            Random randNumEvents = new Random();
            int amountOfEvents; // a random amount of times events will occur

            Random randSeed = new Random(); // seed for random players and teams

            int randEventSeed; // for getting a random sport event

            this.MatchResultOutputString = ""; // reset output string

            if (Match.SportPlayed.GetType() == typeof(Football))
            {
                Football football = new Football();

                amountOfEvents = randNumEvents.Next(10, 18);

                for (int i = 0; i < amountOfEvents; i++)
                {
                    randEventSeed = randSeed.Next(0, Match.SportPlayed.NumEvents);

                    ITeam teamChosen = Match.getRandomTeam(randSeed);

                    if (randEventSeed == 0)
                    {
                        teamChosen.StatList[0].Value++; // increment touchdowns
                        teamChosen.Score += 7;
                        MatchResultOutputString += football.Touchdown(teamChosen.GetRandomPlayer(randSeed));
                    }
                    else if (randEventSeed == 1)
                    {
                        teamChosen.StatList[1].Value++; // increment Interceptions
                        MatchResultOutputString += football.Interception(teamChosen.GetRandomPlayer(randSeed));                       
                    }
                    else if (randEventSeed == 2)
                    {
                        teamChosen.StatList[2].Value++; // increment field goals
                        teamChosen.Score += 3;
                        MatchResultOutputString += football.FieldGoal(teamChosen.GetRandomPlayer(randSeed));
                    }
                    else if (randEventSeed == 3)
                    {
                        teamChosen.StatList[3].Value++; // increment penalties
                        MatchResultOutputString += football.Penalty(teamChosen.GetRandomPlayer(randSeed));
                    }
                }
            }
            else if (Match.SportPlayed.GetType() == typeof(Baseball))
            {
                Baseball baseball = new Baseball();

                amountOfEvents = randNumEvents.Next(6, 12);

                for (int i = 0; i < amountOfEvents; i++)
                {
                    randEventSeed = randSeed.Next(0, Match.SportPlayed.NumEvents);

                    ITeam teamChosen = Match.getRandomTeam(randSeed);

                    if (randEventSeed == 0)
                    {
                        teamChosen.StatList[0].Value++;
                        int scoreAmount = randSeed.Next(1, 4);
                        teamChosen.Score += scoreAmount;
                        MatchResultOutputString += baseball.HomeRun(teamChosen.GetRandomPlayer(randSeed));
                    }
                    else if (randEventSeed == 1)
                    {
                        teamChosen.StatList[1].Value++;
                        teamChosen.Score += 1;
                        MatchResultOutputString += baseball.ScoreRun(teamChosen.GetRandomPlayer(randSeed));                        
                    }
                    else if (randEventSeed == 2)
                    {
                        teamChosen.StatList[2].Value++;
                        teamChosen.Score += 4;
                        MatchResultOutputString += baseball.GrandSlam(teamChosen.GetRandomPlayer(randSeed));
                    }
                }
            }
            else if (Match.SportPlayed.GetType() == typeof(Hockey))
            {
                Hockey hockey = new Hockey();
               
                amountOfEvents = randNumEvents.Next(3, 13);

                for (int i = 0; i < amountOfEvents; i++)
                {
                    randEventSeed = randSeed.Next(0, Match.SportPlayed.NumEvents);

                    ITeam teamChosen = Match.getRandomTeam(randSeed);

                    if (randEventSeed == 0)
                    {
                        teamChosen.StatList[0].Value++;
                        teamChosen.Score += 1;
                        MatchResultOutputString += hockey.Score(teamChosen.GetRandomPlayer(randSeed));                       
                    }
                    else if (randEventSeed == 1)
                    {
                        teamChosen.StatList[1].Value++;
                        MatchResultOutputString += hockey.Fight(teamChosen.GetRandomPlayer(randSeed));                       
                    }
                    else if (randEventSeed == 2)
                    {
                        teamChosen.StatList[2].Value++;
                        MatchResultOutputString += hockey.StealPuck(teamChosen.GetRandomPlayer(randSeed));
                    }
                }
            }
            else if (Match.SportPlayed.GetType() == typeof(Basketball))
            {
                Basketball basketBall = new Basketball();                

                amountOfEvents = randNumEvents.Next(20, 35);

                for (int i = 0; i < amountOfEvents; i++)
                {
                    randEventSeed = randSeed.Next(0, Match.SportPlayed.NumEvents);

                    ITeam teamChosen = Match.getRandomTeam(randSeed);

                    if (randEventSeed == 0)
                    {
                        teamChosen.StatList[0].Value++;
                        teamChosen.Score += 3;
                        MatchResultOutputString += basketBall.ThreePoint(teamChosen.GetRandomPlayer(randSeed));
                    }
                    else if (randEventSeed == 1)
                    {
                        teamChosen.StatList[1].Value++;
                        teamChosen.Score += 2;
                        MatchResultOutputString += basketBall.TwoPoint(teamChosen.GetRandomPlayer(randSeed));
                    }
                    else if (randEventSeed == 2)
                    {
                        teamChosen.StatList[2].Value++;
                        MatchResultOutputString += basketBall.Foul(teamChosen.GetRandomPlayer(randSeed));
                    }
                    else if (randEventSeed == 3)
                    {
                        teamChosen.StatList[3].Value++;
                        teamChosen.Score += 2;
                        MatchResultOutputString += basketBall.Dunk(teamChosen.GetRandomPlayer(randSeed));
                    }
                }
            }
            return MatchResultOutputString;
        }

        public string DeclareWinner()
        {
   
            if(Match.TeamOne.Score > Match.TeamTwo.Score)
            {
                Match.Winner = Match.TeamOne;
            }
            else if (Match.TeamTwo.Score > Match.TeamOne.Score)
            {
                Match.Winner = Match.TeamTwo;
            }
            else
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
