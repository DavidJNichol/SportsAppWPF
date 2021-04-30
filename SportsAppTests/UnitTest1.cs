using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SportsAppDavidNicholOOP.Models;
using SportsAppDavidNicholOOP.Models.Interfaces;

namespace SportsAppTests
{
    [TestClass]
    public class UnitTest1
    {
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
        }

        [TestMethod]
        public void TeamPlayersTest()
        {
            ISport football = new Football();
            ITeam eagles = new Team(football, "Eagles");

            eagles.AddPlayer(new Player("Jeff Meyers"));
            Assert.AreEqual(eagles.PlayerList.Count, 1);
            Assert.AreEqual(eagles.PlayerList[0].Name, "Jeff Meyers"); // name check

            eagles.RemovePlayer(eagles.PlayerList[0]);
            eagles.AddPlayer(new Player("Jeff Meyers", "Fullback"));
            Assert.AreEqual(eagles.PlayerList[0].Position, "Fullback"); // position check

            eagles.PlayerList[0].StatList.Add(new Stat("Running Yards", 100000)); // add a realistic stat

            Assert.AreEqual(eagles.PlayerList[0].StatList[0].Description, "Running Yards"); // stat looks good?
            Assert.AreEqual(eagles.PlayerList[0].StatList[0].Value, 100000);
        }
    }
}
