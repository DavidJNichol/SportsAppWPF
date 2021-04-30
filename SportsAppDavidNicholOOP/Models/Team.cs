using System;
using System.Collections.Generic;
using System.Text;
using SportsAppDavidNicholOOP.Models.Interfaces;

namespace SportsAppDavidNicholOOP.Models
{
    public class Team : ITeam
    {
        public List<IPlayer> PlayerList { get; set; }
        public List<Stat> StatList { get; set; }
        public ISport SportPlayed { get; set; }
        public int ID { get; set; }

        public string Name { get; set; }

        public Team(ISport sport, string name)
        {
            this.SportPlayed = sport;
            this.Name = name;
            this.ID = 404;
            this.StatList = new List<Stat>();
            this.PlayerList = new List<IPlayer>();
        }

        public void AddPlayer(IPlayer player)
        {
            this.PlayerList.Add(player);
        }

        public void RemovePlayer(IPlayer player)
        {
            this.PlayerList.Remove(player);
        }
    }
}
