using System;
using System.Collections.Generic;
using System.Text;

namespace SportsAppDavidNicholOOP.Models.Interfaces
{
    public interface IMatch
    {
        ITeam TeamOne{ get; set; }
        ITeam TeamTwo { get; set; }

        ISport SportPlayed { get; set; }

        string Time { get; set; }

        string Date { get; set; }

        string About { get; set; }
    }
}
