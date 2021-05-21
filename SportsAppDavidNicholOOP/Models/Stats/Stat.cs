using SportsAppDavidNicholOOP.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsAppDavidNicholOOP.Models
{
    [Serializable]
    public class Stat : IStat
    {
        public string Description { get; set; }
        public float Value { get; set; }

        public Stat(string description, float value)
        {
            this.Description = description;
            this.Value = value;
        }

        public string AboutMessage()
        {
            string statListAbout = "";

            statListAbout += $"{this.Value} {this.Description} "; 

            return statListAbout; // team earned value description
        }
    }
}
