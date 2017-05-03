using NUnit.Framework;
using Rummikub;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RummikubTests
{
    [TestFixture]
    public class ShuffleTests
    {
        [Test]
        public void Tiles_hasColorPieces_withSameCount()
        {
            var pool = new TilePool(tilesPerColor: 13, jokerTiles: 2);

            foreach (TileColor color in Enum.GetValues(typeof(TileColor)))
            {
                IList colorTiles = (from x in pool.Tiles
                                    where x.Color == color && x.Value != 25
                                    select x).ToList();
                Assert.AreEqual(13 * 2, colorTiles.Count);
            }
        }

        [Test]
        public void Tiles_hasJokers_onlyTwo()
        {
            var pool = new TilePool(tilesPerColor: 13, jokerTiles: 2);

            IList jokerTiles = (from x in pool.Tiles
                                where x.Value == 25
                                select x).ToList();

            Assert.AreEqual(2, jokerTiles.Count);
        }

        [Test]
        public void Tiles_areOrdered()
        {
            var pool = new TilePool(tilesPerColor: 13, jokerTiles: 2);

            IList<Tile> expectedSort = pool.Tiles.OrderBy(x => x.Index).ToList();

            CollectionAssert.AreEqual(expectedSort, pool.Tiles);
        }

        [Test]
        public void Tiles_areShuffled()
        {
            var pool = new TilePool(tilesPerColor: 13, jokerTiles: 2);

            IList<Tile> orderedTiles = pool.Tiles.OrderBy(x => x.Index).ToList();
            pool.Shuffle();

            CollectionAssert.AreNotEqual(orderedTiles, pool.Tiles);
        }
    }
}
