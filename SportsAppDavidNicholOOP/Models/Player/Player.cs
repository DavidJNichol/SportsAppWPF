using System;
using System.Collections.Generic;
using System.Text;
using SportsAppDavidNicholOOP.Models.Interfaces;

namespace SportsAppDavidNicholOOP.Models
{
    [Serializable]
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public string Position { get; set; }

        public Player(string name, string optionalPosition = "Default Position") // some sports don't have positions
        {
            this.Name = name;
            this.Position = optionalPosition;
        }
    }
}
