using System;
using System.Collections.Generic;
using System.Text;

namespace SportsAppDavidNicholOOP.Models.Interfaces
{
    public interface IMatch
    {
        ITeam TeamOne{ get; set; }
        ITeam TeamTwo { get; set; }
        ITeam Winner { get; set; }
        ISport SportPlayed { get; set; }
        void SetWinner(ITeam team);

        string Time { get; set; }

        string Date { get; set; }

        string About { get; set; }

        ITeam getRandomTeam(Random seed);
    }
}
