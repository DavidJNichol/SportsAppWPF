using SportsAppDavidNicholOOP.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsAppDavidNicholOOP.Models
{
    public class Stat : IStat
    {
        public string Description { get; set; }
        public float Value { get; set; }
        public string About { get; set; }

        public Stat(string description, float value)
        {
            this.Description = description;
            this.Value = value;
            this.About = "Default Stat About";
        }
    }
}
