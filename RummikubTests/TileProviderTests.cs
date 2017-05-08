using NUnit.Framework;
using Rummikub;
using System.Collections.Generic;
using System.Linq;

namespace RummikubTests
{
    [TestFixture]
    public class TileProviderTests
    {
        [Test]
        public void TileProvider_createTiles()
        {
            IList<Tile> tiles = TileProvider.Create("B1, B2, B3");

            Assert.IsNotNull(tiles);
            Assert.IsNotNull(tiles.Where(x => x.Color == TileColor.Blue && x.Value == 1).FirstOrDefault());
            Assert.IsNotNull(tiles.Where(x => x.Color == TileColor.Blue && x.Value == 2).FirstOrDefault());
            Assert.IsNotNull(tiles.Where(x => x.Color == TileColor.Blue && x.Value == 3).FirstOrDefault());
        }

        [Test]
        public void TileProvider_ignoresInvalidEntries()
        {
            IList<Tile> tiles = TileProvider.Create("B1, X2");

            Assert.IsNotNull(tiles);
            Assert.IsTrue(tiles.Count == 1);
            Assert.IsNotNull(tiles.Where(x => x.Color == TileColor.Blue && x.Value == 1).FirstOrDefault());
        }

        [Test]
        public void TileProvider_whenEmptyString_doesNotCreateTiles()
        {
            IList<Tile> tiles = TileProvider.Create("");

            CollectionAssert.IsEmpty(tiles);
        }

        [Test]
        public void TileProvider_canParseEachColor()
        {
            IList<Tile> tiles = TileProvider.Create("R1, G2, B3, O4");

            Assert.IsNotNull(tiles);
            Assert.IsNotNull(tiles.Where(x => x.Color == TileColor.Red && x.Value == 1).FirstOrDefault());
            Assert.IsNotNull(tiles.Where(x => x.Color == TileColor.Green && x.Value == 2).FirstOrDefault());
            Assert.IsNotNull(tiles.Where(x => x.Color == TileColor.Blue && x.Value == 3).FirstOrDefault());
            Assert.IsNotNull(tiles.Where(x => x.Color == TileColor.Orange && x.Value == 4).FirstOrDefault());
        }
    }
}
