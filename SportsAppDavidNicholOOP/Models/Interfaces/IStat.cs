using System;
using System.Collections.Generic;
using System.Text;

namespace SportsAppDavidNicholOOP.Models.Interfaces
{
    public interface IStat
    {
        string Description { get; set; }
        float Value { get; set; }

        string AboutMessage(IPlayer player);
    }
}
