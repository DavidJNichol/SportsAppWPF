using System;
using System.Collections.Generic;
using System.Text;

namespace SportsAppDavidNicholOOP.Models
{
    public class Sport : ISport
    {
        public string Name { get; set; }

        public Sport()
        {
            Name = "Default Sport Name";
        }
    }
}
