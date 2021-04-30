using SportsAppDavidNicholOOP.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsAppDavidNicholOOP.Models
{
    class MatchResult : IMatchResult
    {
        public IMatch Match { get; set; }
        public string About { get; set; }

        public MatchResult(IMatch match)
        {
            this.Match = match;
            this.About = "Default MatchResult About";
        }
    }
}
