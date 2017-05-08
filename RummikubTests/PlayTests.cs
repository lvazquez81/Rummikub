using Moq;
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
    public class PlayTests
    {
        [Test]
        public void Player_playsInitialGame()
        {
            var pool = new Mock<ITilePool>();
            pool.Setup(x => x.GetStartingTiles())
                .Returns(TileProvider.Create("B10, B11, B12"));
            var game = new RummikubGame();
            Player p = game.CreatePlayer("Rossy");
            
        }
    }
}
