using System;
using System.Collections.Generic;
using System.Text;

namespace SportsAppDavidNicholOOP.Models.Interfaces
{
    public interface IMatchResult
    {
        IMatch Match { get; set; }

        string MatchResultOutputString { get; set; }

        string PrintMatchEvents(); 

        string DeclareWinner();

        string DeclareTie();
    }
}
