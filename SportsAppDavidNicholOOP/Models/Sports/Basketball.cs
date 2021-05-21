using SportsAppDavidNicholOOP.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAppDavidNicholOOP.Models.Sports
{
    [Serializable]
    public class Basketball : BallSport
    {
        public Basketball()
        {
            this.Name = "Basketball";
            this.ballType = "Basketball";
            this.NumEvents = 4;
        }

        public string ThreePoint(IPlayer player)
        {            
            return $"{player.Name} scored a three.\n";
        }

        public string TwoPoint(IPlayer player)
        {
            return $"{player.Name} scored a two.\n";
        }

        public string Foul(IPlayer player)
        {
            return $"{player.Name} fouled.\n";
        }

        public string Dunk(IPlayer player)
        {
            return $"{player.Name} dunked.\n";
        }
    }
}
