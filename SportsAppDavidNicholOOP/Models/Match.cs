using SportsAppDavidNicholOOP.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsAppDavidNicholOOP.Models
{
    class Match : IMatch
    {
        public ITeam TeamOne { get; set; }
        public ITeam TeamTwo { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string About { get; set; }
        public ISport SportPlayed { get; set; }

        public Match(ITeam teamOne, ITeam teamTwo)
        {
            this.TeamOne = teamOne;
            this.TeamTwo = teamTwo;
            this.Date = "Default Date";
            this.Time = "Default Time";

            this.About = $"Lovely day to play some {this.SportPlayed}. Today we have {TeamOne.Name} versus {TeamTwo.Name}.";
        }
    }
}
