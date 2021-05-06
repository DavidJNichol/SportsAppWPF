using System;
using System.Collections.Generic;
using System.Text;

namespace SportsAppDavidNicholOOP.Models
{
    public interface ISport
    {
        string Name { get; set; }

        int NumEvents { get; set; } // number of methods within the sport that could be called (score touchdown, hit homerun etc)
    }
}
