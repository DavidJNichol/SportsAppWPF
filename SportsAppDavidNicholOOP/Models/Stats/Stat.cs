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

        public Stat(string description, float value)
        {
            this.Description = description;
            this.Value = value;
        }

        public string AboutMessage(IPlayer player)
        {
            string statListAbout = "";
            for(int i = 0; i < player.StatList.Count; i++)
            {
                statListAbout += $"{player.StatList[i].Value} {player.StatList[i].Description} "; 
            }

            return $"{player.Name} earned {statListAbout}"; // player earned value description
        }
    }
}
