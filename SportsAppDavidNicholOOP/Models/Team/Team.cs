using System;
using System.Collections.Generic;
using System.Text;
using SportsAppDavidNicholOOP.Models.Interfaces;
using SportsAppDavidNicholOOP.Models.Sports;

namespace SportsAppDavidNicholOOP.Models.Team
{
    [Serializable]
    public class Team : ITeam
    {
        public List<IPlayer> PlayerList { get; set; }
        public List<Stat> StatList { get; set; }
        public ISport SportPlayed { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }

        public Team(string name)
        {
            this.Name = name;
            this.ID = 404;
            this.StatList = new List<Stat>();
            this.PlayerList = new List<IPlayer>();
        }


        public Team(ISport sport, string name)
        {
            this.SportPlayed = sport;
            this.Name = name;
            this.ID = 404;
            this.StatList = new List<Stat>();
            this.PlayerList = new List<IPlayer>();
            InitializeStats();
        }

        public void AddPlayer(IPlayer player)
        {
            this.PlayerList.Add(player);
        }

        public void RemovePlayer(IPlayer player)
        {
            this.PlayerList.Remove(player);
        }

        public IPlayer GetRandomPlayer(Random seed)
        {
            int randNum = seed.Next(0, PlayerList.Count);
            try
            {
                return PlayerList[randNum];
            }
            catch
            {
                throw new ArgumentException("PlayerList Cannot be null! Add players.");
            }
        }

        public void InitializeStats()
        {
            if (this.SportPlayed.GetType() == typeof(Football))
            {
                this.StatList.Add(new Stat("Touchdowns", 0));
                this.StatList.Add(new Stat("Interceptions", 0));
                this.StatList.Add(new Stat("Field Goals", 0));
                this.StatList.Add(new Stat("Penalties", 0));
            }
            else if (this.SportPlayed.GetType() == typeof(Baseball))
            {
                this.StatList.Add(new Stat("Home Runs", 0));
                this.StatList.Add(new Stat("Runs Scored", 0));
                this.StatList.Add(new Stat("Grand Slams", 0));
            }
            else if (this.SportPlayed.GetType() == typeof(Hockey))
            {
                this.StatList.Add(new Stat("Goals Scored", 0));
                this.StatList.Add(new Stat("Fights", 0));
                this.StatList.Add(new Stat("Pucks Stolen", 0));
            }
            else if (this.SportPlayed.GetType() == typeof(Basketball))
            {
                this.StatList.Add(new Stat("Threes", 0));
                this.StatList.Add(new Stat("Twos", 0));
                this.StatList.Add(new Stat("Fouls", 0));
                this.StatList.Add(new Stat("Dunks", 0));
            }
        }
    }
}
