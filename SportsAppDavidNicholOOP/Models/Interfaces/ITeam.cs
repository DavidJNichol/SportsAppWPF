using System;
using System.Collections.Generic;
using System.Text;

namespace SportsAppDavidNicholOOP.Models.Interfaces
{
    public interface ITeam
    {
        ISport SportPlayed { get; set; }

        int ID { get; set; }

        string Name { get; set; }

        List<IPlayer> PlayerList { get; set; }

        List<Stat> StatList { get; set; }

        void AddPlayer(IPlayer player);

        void RemovePlayer(IPlayer player);

        IPlayer GetRandomPlayer(int randNum); // change back to a Random class argument seed after testing
    }
}
