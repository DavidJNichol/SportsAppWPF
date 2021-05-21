using SportsAppDavidNicholOOP.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAppDavidNicholOOP.Models.Sports
{
    [Serializable]
    public class Baseball : BallSport
    {
        public Baseball()
        {
            this.Name = "Baseball";
            this.ballType = "Baseball";
            this.NumEvents = 3;
        }

        public string HomeRun(IPlayer player)
        {
            return $"{player.Name} hit a home run.\n";
        }

        public string ScoreRun(IPlayer player)
        {
            return $"{player.Name} scored a run.\n";
        }

        public string GrandSlam(IPlayer player)
        {
            return $"{player.Name} hit a grand slam.\n";
        }
    }
}
