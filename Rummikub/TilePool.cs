using System;
using System.Linq;
using System.Collections.Generic;

namespace Rummikub
{
    public class TilePool
    {
        private readonly int _tilesPerPlayer = 14;
        private readonly int _tilesPerColor = 13;
        private readonly IList<Tile> _pool;
        private readonly IList<int> _usedTiles;
        private readonly Random _random;
        private int _seedIndex;

        public TilePool(int tilesPerColor, int jokerTiles)
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
            var jokerOne = new Tile(TileColor.Black, value: 25, index: _seedIndex++);
            _pool.Add(jokerOne);

            var jokerTwo = new Tile(TileColor.Red, value: 25, index: _seedIndex++);
            _pool.Add(jokerTwo);
        }

        private void InitializeTileGroup(TileColor color)
        {
            for (int i = 0; i < _tilesPerColor; i++)
            {
                var tileOne = new Tile(color, i + 1, _seedIndex++);
                _pool.Add(tileOne);

                var tileTwo = new Tile(color, i + 1, _seedIndex++);
                _pool.Add(tileTwo);
            }
        }

        public IList<Tile> GetInitialTiles()
        {
            IList<Tile> tiles = new List<Tile>();

            for (int i = 0; i < _tilesPerPlayer; i++)
            {
                Tile tile = new Tile(TileColor.Blue, i + 1, i);
                tiles.Add(tile);
            }

            return tiles;
        }

        public IList<Tile> Tiles
        {
            get { return _pool; }
        }

    }
}
