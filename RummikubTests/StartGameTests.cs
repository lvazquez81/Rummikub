using NUnit.Framework;
using Rummikub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RummikubTests
{
    [TestFixture]
    public class StartGameTests
    {
        [Test]
        public void StartGame_hasPlayerNames()
        {
            var game = new RummikubGame();
            game.Initialize("Rossy", "Luis", "Fer", "Coco");

            Assert.IsNotNull(game.GetPlayer("Rossy"));
            Assert.IsNotNull(game.GetPlayer("Luis"));
            Assert.IsNotNull(game.GetPlayer("Fer"));
            Assert.IsNotNull(game.GetPlayer("Coco"));
        }

        [Test]
        public void StartGame_allPlayers_have14Tiles()
        {
            var game = new RummikubGame();
            game.Initialize("Rossy", "Luis", "Fer", "Coco");

            Assert.IsTrue(game.GetPlayer("Rossy").Tiles.Count == 14);
            Assert.IsTrue(game.GetPlayer("Luis").Tiles.Count == 14);
            Assert.IsTrue(game.GetPlayer("Fer").Tiles.Count == 14);
            Assert.IsTrue(game.GetPlayer("Coco").Tiles.Count == 14);
        }
    }
}
