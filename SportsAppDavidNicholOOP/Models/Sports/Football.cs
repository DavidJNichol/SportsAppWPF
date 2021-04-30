using System;
using System.Collections.Generic;
using System.Text;

namespace SportsAppDavidNicholOOP.Models
{
    public class Football : ISport
    {
        public string Name { get; set; }

        public Football()
        {
            this.Name = "Football";
        }
    }
}
