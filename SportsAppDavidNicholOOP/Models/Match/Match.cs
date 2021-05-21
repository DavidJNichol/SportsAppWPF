using SportsAppDavidNicholOOP.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SportsAppDavidNicholOOP.Models.Team;
using SportsAppDavidNicholOOP.Models.Sports;

namespace SportsAppDavidNicholOOP.Models
{
    [Serializable]
    public class Match : IMatch
    {
        public ITeam TeamOne { get; set; }
        public ITeam TeamTwo { get; set; }
        public ITeam Winner { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string About { get; set; }
        public ISport SportPlayed { get; set; }

        public Match(ITeam teamOne, ITeam teamTwo, string date, string time, ISport sportPlayed)
        {
            this.TeamOne = teamOne;
            this.TeamTwo = teamTwo;
            this.Date = date;
            this.Time = time;
            this.SportPlayed = sportPlayed;
            
            if(this.SportPlayed == null)
            {
                this.SportPlayed = new Sport();
            }


            this.About = $"Lovely day to play some {this.SportPlayed.Name}. We have {TeamOne.Name} versus {TeamTwo.Name} on ";
        }
        public void SetWinner(ITeam team)
        {
            this.Winner = team;
        }

        public ITeam getRandomTeam(Random seed) // change back to a Random class argument seed after testing
        {
            int randNum = seed.Next(0, 2);

            if(randNum == 0)
            {
                return this.TeamOne;
            }
            else
            {
                return this.TeamTwo;
            }
        }
    }
}
