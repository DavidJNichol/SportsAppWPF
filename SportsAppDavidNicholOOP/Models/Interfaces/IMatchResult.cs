using System;
using System.Collections.Generic;
using System.Text;

namespace SportsAppDavidNicholOOP.Models.Interfaces
{
    public interface IMatchResult
    {
        IMatch Match { get; set; }

        string MatchResultOutputString { get; set; }

        string PrintMatchEvents(int forcedSeed, int forcedTeam, int forcedPlayer, int amountOfTimes); // args for testing only

        string DeclareWinner();

        string DeclareTie();
    }
}
