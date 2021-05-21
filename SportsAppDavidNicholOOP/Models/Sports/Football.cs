using SportsAppDavidNicholOOP.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsAppDavidNicholOOP.Models
{
    [Serializable]
    public class Football : BallSport
    {       
        public Football()
        {
            this.Name = "Football";
            this.ballType = "Football";
            this.NumEvents = 4;
        }

        public string Touchdown(IPlayer player)
        {
            return $"{player.Name} scored a touchdown.\n"; // increase score?? possibly take in a iteam argument
        }

        public string Interception(IPlayer player)
        {
            return $"{player.Name} intercepted the ball.\n";
        }

        public string FieldGoal(IPlayer player)
        {
            return $"{player.Name} kicked a field goal.\n";
        }

        public string Penalty(IPlayer player)
        {
            return $"{player.Name} got flagged for a penalty.\n";
        }

    }
}
