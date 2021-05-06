using SportsAppDavidNicholOOP.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAppDavidNicholOOP.Models.Sports
{
    public class Hockey : Sport
    {
        public Hockey()
        {
            this.Name = "Hockey";
            this.NumEvents = 3;
        }

        public string Score(IPlayer player)
        {
            return $"{player.Name} scored a goal.\n";
        }

        public string Fight(IPlayer player)
        {
            return $"{player.Name} got in a fight.\n";
        }

        public string StealPuck(IPlayer player)
        {
            return $"{player.Name} stole the puck.\n";
        }

    }
}
