using NUnit.Framework;
using Rummikub;

namespace RummikubTests
{
    [TestFixture]
    public class PlayTests
    {
        [Test]
        public void Play_onSequenceNumber_returnsValid()
        {
            var game = new RummikubGame();
            Player p = game.CreatePlayer("Rossy");

            bool valid = game.Play(p, "B10, B11, B12");

            Assert.IsTrue(valid);
        }

        [Test]
        public void Play_onIncompleteSequenceNumber_returnsInvalid()
        {
            var game = new RummikubGame();
            Player p = game.CreatePlayer("Rossy");

            bool valid = game.Play(p, "B6, B7, B10");

            Assert.IsFalse(valid);
        }

        [Test]
        public void Play_onColorMissmatchSequenceNumber_returnsInvalid()
        {
            var game = new RummikubGame();
            Player p = game.CreatePlayer("Rossy");

            bool valid = game.Play(p, "B6, B7, B10");

            Assert.IsFalse(valid);
        }

        [Test]
        public void Play_onMirrorPlay_returnsValid()
        {
            var game = new RummikubGame();
            Player p = game.CreatePlayer("Rossy");

            bool valid = game.Play(p, "R10, G10, B10");

            Assert.IsTrue(valid);
        }

        [Test]
        public void Play_onMirrorPlay_withDuplicateColor_returnsInvalid()
        {
            var game = new RummikubGame();
            Player p = game.CreatePlayer("Rossy");

            bool valid = game.Play(p, "R10, G10, G10");

            Assert.IsFalse(valid);
        }

        [Test]
        public void Play_onMirrorPlay_withSameColor_returnsInvalid()
        {
            var game = new RummikubGame();
            Player p = game.CreatePlayer("Rossy");

            bool valid = game.Play(p, "R10, R10, R10");

            Assert.IsFalse(valid);
        }

        [Test]
        public void Play_oneTile_returnsInvalid()
        {
            var game = new RummikubGame();
            Player p = game.CreatePlayer("Rossy");

            bool valid = game.Play(p, "R10");

            Assert.IsFalse(valid);
        }

        [Test]
        public void Play_twoTiles_returnsInvalid()
        {
            var game = new RummikubGame();
            Player p = game.CreatePlayer("Rossy");

            bool valid = game.Play(p, "R10, R11");

            Assert.IsFalse(valid);
        }
    }
}
