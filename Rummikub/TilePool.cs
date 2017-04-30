using System;
using System.Linq;
using System.Collections.Generic;

namespace Rummikub
{
    public class TilePool
    {
        private const int TILES_PER_PLAYER = 14;
        private const int TILES_PER_COLOR = 13;
        private readonly IList<Tile> _pool;
        private readonly IList<int> _usedTiles;
        private readonly Random _random;
        private int _seedIndex;

        public TilePool()
        {
            _random = new Random();
            _pool = new List<Tile>();
            _seedIndex = 0;
            _usedTiles = new List<int>();

            InitializeTileGroup(TileColor.Black);
            InitializeTileGroup(TileColor.Blue);
            InitializeTileGroup(TileColor.Orange);
            InitializeTileGroup(TileColor.Red);
            AddJokerTiles();
        }

        private void AddJokerTiles()
        {
            var jokerOne = new Tile(TileColor.Black, value: -1, index: _seedIndex++);
            _pool.Add(jokerOne);

            var jokerTwo = new Tile(TileColor.Red, value: -1, index: _seedIndex++);
            _pool.Add(jokerTwo);
        }

        private void InitializeTileGroup(TileColor color)
        {
            for (int i = 0; i < TILES_PER_COLOR; i++)
            {
                var tileOne = new Tile(color, i + 1, _seedIndex++);
                _pool.Add(tileOne);

                var tileTwo = new Tile(color, i + 1, _seedIndex++);
                _pool.Add(tileTwo);
            }
        }

      
    }
}
