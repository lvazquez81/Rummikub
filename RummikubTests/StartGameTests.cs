using NUnit.Framework;
using Rummikub;

namespace RummikubTests
{
    [TestFixture]
    public class StartGameTests
    {
        RummikubGame _game;

        [SetUp]
        public void TestSetup()
        {
            _game = new RummikubGame();
        }


        [Test]
        public void InitializePlayer_hasName_andTiles()
        {
            Player p = _game.CreatePlayer(playerName: "Rossy");

            Assert.IsNotNull(p);
            StringAssert.AreEqualIgnoringCase("Rossy", p.Name);
        }

        [Test]
        public void SetupPlayerOrder()
        {
            Player p1 = _game.CreatePlayer(playerName: "Rossy");
            Player p2 = _game.CreatePlayer(playerName: "Luis");
            Player p3 = _game.CreatePlayer(playerName: "Fer");
            Player p4 = _game.CreatePlayer(playerName: "Coco");

            _game.SetupGame(p1, p2, p3, p4);

            CollectionAssert.Contains(_game.Players, "Rossy");
            Assert.IsTrue(_game.GetPlayer("Rossy").Order > 0);

            CollectionAssert.Contains(_game.Players, "Luis");
            Assert.IsTrue(_game.GetPlayer("Luis").Order > 0);

            CollectionAssert.Contains(_game.Players, "Fer");
            Assert.IsTrue(_game.GetPlayer("Fer").Order > 0);

            CollectionAssert.Contains(_game.Players, "Coco");
            Assert.IsTrue(_game.GetPlayer("Coco").Order > 0);
        }

        [Test]
        public void EachPlayer_getsTiles()
        {
            var game = new RummikubGame();
            Player p = game.CreatePlayer(playerName: "Rossy");

            game.GetInitialTiles(p);

            CollectionAssert.IsNotEmpty(p.Tiles);
        }

    }
}
