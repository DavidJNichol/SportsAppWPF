using System;
using System.Collections.Generic;
using System.Text;
using SportsAppDavidNicholOOP.Models.Interfaces;

namespace SportsAppDavidNicholOOP.Models
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public List<Stat> StatList { get; set; }

        public Player(string name, string optionalPosition = "Default Position")
        {
            this.Name = name;
            this.Position = optionalPosition;
            this.StatList = new List<Stat>();
        }
    }
}
