using System.Collections.Generic;

namespace Rummikub
{
    public interface ITilePool
    {
        void Shuffle();
        IList<Tile> GetStartingTiles();
        Tile GetSpareTile();
    }
}
