using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAppDavidNicholOOP.Models
{
    public class BallSport : Sport // kind of a useless class
    {
        public string ballType { get; set; }

        public BallSport()
        {
            this.Name = "Default Ball Sport";
            this.ballType = "Default Ball Type";
        }
    }
}
