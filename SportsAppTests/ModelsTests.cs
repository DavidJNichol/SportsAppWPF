using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SportsAppDavidNicholOOP.Models;
using SportsAppDavidNicholOOP.Models.Interfaces;
using SportsAppDavidNicholOOP.Models.Team;
using SportsAppDavidNicholOOP.Models.Sports;
using System.Collections.Generic;
using Moq;

namespace SportsAppTests
{
    [TestClass]
    public class ModelsTests
    {
        [TestMethod]
        public void MoqTest()
        {
            var mockSport = new Mock<ISport>();
            mockSport.Setup(s => s.Name).Returns("Mock Sport");
            mockSport.Setup(s => s.NumEvents).Returns(3);
            ITeam testTeam = new Team(mockSport.Object, "Test Team");
            Assert.AreEqual(testTeam.SportPlayed.Name, "Mock Sport");
            Assert.AreEqual(testTeam.SportPlayed.NumEvents, 3);

            var MockPlayer = new Mock<IPlayer>();
            MockPlayer.Setup(s => s.Name).Returns("Larry Jones");
            MockPlayer.Setup(s => s.Position).Returns("Center");
            MockPlayer.Setup(s => s.StatList).Returns(new List<Stat>());

            testTeam.AddPlayer(MockPlayer.Object);

            Assert.AreEqual(testTeam.PlayerList[0].Name, "Larry Jones");
            Assert.AreEqual(testTeam.PlayerList[0].Position, "Center");
            Assert.IsNotNull(testTeam.StatList);
        }


        [TestMethod]
        public void TeamDefaultInitsTest()
        {
            ISport football = new Football();
            ITeam eagles = new Team(football, "Eagles");          

            Assert.AreEqual(eagles.Name, "Eagles");
            Assert.AreEqual(eagles.ID, 404); // 404 is default ID

            Assert.AreEqual(eagles.PlayerList.Count, 0);
            Assert.AreEqual(eagles.SportPlayed.Name, "Football");
            Assert.AreEqual(eagles.StatList.Count, 0);

            ISport baseball = new Baseball();
            eagles = new Team(baseball, "Eagles");
            Assert.AreEqual(eagles.SportPlayed.Name, "Baseball");

            ISport basketBall = new Basketball();
            eagles = new Team(basketBall, "Eagles");
            Assert.AreEqual(eagles.SportPlayed.Name, "Basketball");
        }

        [TestMethod]
        public void TeamPlayersTest()
        {
            ISport football = new Football();
            ITeam eagles = new Team(football, "Eagles");

            Assert.AreEqual(eagles.SportPlayed, football);
            Assert.AreEqual(eagles.Name, "Eagles");

            eagles.AddPlayer(new Player("Jeff Meyers"));
            Assert.AreEqual(eagles.PlayerList.Count, 1);
            Assert.AreEqual(eagles.PlayerList[0].Name, "Jeff Meyers"); // name check

            eagles.RemovePlayer(eagles.PlayerList[0]);
            eagles.AddPlayer(new Player("Jeff Meyers", "Fullback"));
            Assert.AreEqual(eagles.PlayerList[0].Position, "Fullback"); // position check

            eagles.AddPlayer(new Player("David Nichol"));

            Assert.AreEqual(eagles.PlayerList[1].Name, "David Nichol"); // name check
                      
            eagles.RemovePlayer(eagles.PlayerList[0]); // sorry jeff, just didn't work out this season
            // today I learned removing from a list bumps down indicies. This removes me, not jeff
            eagles.RemovePlayer(eagles.PlayerList[0]); 

            Assert.AreEqual(eagles.PlayerList.Count, 0);
        }

        [TestMethod]
        public void PlayerStatTests()
        {
            ITeam eagles = new Team(new Football(), "Eagles");

            eagles.AddPlayer(new Player("Jeff Meyers", "Fullback"));

            eagles.AddPlayer(new Player("David Nichol", "Quarterback"));

            eagles.PlayerList[0].StatList.Add(new Stat("Rushing Yards", 100000)); // add a realistic stat

            Assert.AreEqual(eagles.PlayerList[0].StatList[0].Description, "Rushing Yards"); // stat looks good?
            Assert.AreEqual(eagles.PlayerList[0].StatList[0].Value, 100000);

            Assert.AreEqual(eagles.PlayerList[0].StatList[0].AboutMessage(eagles.PlayerList[0]), "Jeff Meyers earned 100000 Rushing Yards "); // check that stat about is good

            eagles.PlayerList[0].StatList.Add(new Stat("Receptions", 100)); // add another stat

            Assert.AreEqual(eagles.PlayerList[0].StatList[0].AboutMessage(eagles.PlayerList[0]), "Jeff Meyers earned 100000 Rushing Yards 100 Receptions "); // check that stat about is good

            eagles.PlayerList[1].StatList.Add(new Stat("Passing Yards", 20000));

            Assert.AreEqual(eagles.PlayerList[1].StatList[0].AboutMessage(eagles.PlayerList[1]), "David Nichol earned 20000 Passing Yards ");

            eagles = new Team(new Hockey(), "Eagles"); // hockey time
            eagles.AddPlayer(new Player("Jeff Meyers", "Right Defenseman"));

            eagles.PlayerList[0].StatList.Add(new Stat("Bones Broken", 99999)); // nice

            Assert.AreEqual(eagles.PlayerList[0].StatList[0].AboutMessage(eagles.PlayerList[0]), "Jeff Meyers earned 99999 Bones Broken ");

        }

        [TestMethod]
        public void MatchTests()
        {
            ITeam bears = new Team(new Football(), "Bears");
            ITeam packers = new Team(new Football(), "Packers");

            string date = "02/17/21";

            string time = "8:00 PM";

            // bears vs packers, 02/17/21 at 8PM. Sportplayed is football
            IMatch superBowl = new SportsAppDavidNicholOOP.Models.Match(bears,packers, date, time, bears.SportPlayed); 

            Assert.AreEqual(superBowl.TeamOne, bears);
            Assert.AreEqual(superBowl.TeamTwo, packers);
            Assert.AreEqual(superBowl.Date, "02/17/21");
            Assert.AreEqual(superBowl.Time, "8:00 PM");
            Assert.AreEqual(superBowl.SportPlayed.Name, "Football");
            Assert.AreEqual(superBowl.About, "Lovely day to play some Football on 02/17/21. We have Bears versus Packers at 8:00 PM.");

            superBowl.SetWinner(bears);

            Assert.AreEqual(superBowl.Winner, bears); // in our dreams

            IMatchResult superBowlResult = new MatchResult(superBowl);

            Assert.AreEqual(superBowlResult.DeclareWinner(), $"This exciting Bears vs. Packers match on 02/17/21 resulted in a Bears Victory."); // Match result if there is a winner

            Assert.AreEqual(superBowlResult.DeclareTie(), $"This exciting Bears vs. Packers match on 02/17/21 resulted in a draw.");       
        }     

        [TestMethod]
        public void MatchResultsTests()
        {
            /* 
             * So Sporting 'events' like scoring a goal are all going to be an outputted list of strings on a wpf window.
             * things like 'james smith scored a touchdown.' with a random player from a random team, a random number of times.
             * In order to test this, I had to modify my match, team and matchresults classes quite a bit so i can force 
             * what the output could be. Much of my matchresults printevents method will change after these tests.
             */

            ITeam panthers = new Team(new Baseball(), "Panthers");
            ITeam knights = new Team(new Baseball(), "Knights");

            IMatch match = new SportsAppDavidNicholOOP.Models.Match(panthers, knights, "01/02/03", "13 PM", panthers.SportPlayed);
            IMatchResult matchResult = new MatchResult(match);

            panthers.AddPlayer(new Player("Shiny Joe Harris"));
            panthers.AddPlayer(new Player("Slim Thomas Keller"));
            panthers.AddPlayer(new Player("Paul Lee"));
            panthers.AddPlayer(new Player("Crazy Hugh Porter"));

            knights.AddPlayer(new Player("Quick Mark Hammond"));
            knights.AddPlayer(new Player("Nick Sherman"));
            knights.AddPlayer(new Player("James Key"));
            knights.AddPlayer(new Player("Strongarm Will Campos"));

            /* first match result arg is a sport event, second is the team, third is the player from that team, fourth is the 
            num times it will run.
            2 is score run, 0 is panthers, 3 is crazy hugh porter, 1 is the amount of times it will print*/
            Assert.AreEqual(matchResult.PrintMatchEvents(2, 0, 3, 1), "Crazy Hugh Porter scored a run.\n");
            Assert.AreEqual(matchResult.PrintMatchEvents(0, 1, 0, 2), "Quick Mark Hammond hit a home run.\nQuick Mark Hammond hit a home run.\n");
            Assert.AreEqual(matchResult.PrintMatchEvents(1, 0, 2, 1), "Paul Lee hit a grand slam.\n");

            match.SportPlayed = new Basketball(); // basketball time
            Assert.AreEqual(matchResult.PrintMatchEvents(2, 0, 1, 1), "Slim Thomas Keller fouled.\n");
            Assert.AreEqual(matchResult.PrintMatchEvents(0, 1, 1, 2), "Nick Sherman scored a three.\nNick Sherman scored a three.\n");
            Assert.AreEqual(matchResult.PrintMatchEvents(3, 1, 3, 1), "Strongarm Will Campos dunked.\n");

        }
    }
}
