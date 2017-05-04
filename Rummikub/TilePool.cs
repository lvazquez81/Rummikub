using System;
using System.Linq;
using System.Collections.Generic;

namespace Rummikub
{
    public class TilePool
    {
        private readonly int _tilesPerPlayer = 14;
        private readonly int _tilesPerColor = 13;
        private readonly IList<TileControl> _pool;
        private readonly IList<int> _usedTiles;
        private int _seedIndex;

        public TilePool(int tilesPerColor, int jokerTiles)
        {
            _pool = new List<TileControl>();
            _seedIndex = 0;
            _usedTiles = new List<int>();

            InitializeTileGroup(TileColor.Black);
            InitializeTileGroup(TileColor.Blue);
            InitializeTileGroup(TileColor.Orange);
            InitializeTileGroup(TileColor.Red);
            AddJokerTiles();

            this.Shuffle();
        }

        private void AddJokerTiles()
        {
            var jokerOne = new TileControl(TileColor.Black, value: 25, index: _seedIndex++);
            _pool.Add(jokerOne);

            var jokerTwo = new TileControl(TileColor.Red, value: 25, index: _seedIndex++);
            _pool.Add(jokerTwo);
        }

        private void InitializeTileGroup(TileColor color)
        {
            for (int i = 0; i < _tilesPerColor; i++)
            {
                var tileOne = new TileControl(color, i + 1, _seedIndex++);
                _pool.Add(tileOne);

                var tileTwo = new TileControl(color, i + 1, _seedIndex++);
                _pool.Add(tileTwo);
            }
        }

        public IList<Tile> GetInitialTiles(string playerName)
        {
            this.Shuffle();

            IList<TileControl> availableTiles = (from x in this.Tiles
                                                 where x.Owner == null
                                                 select x).ToList();

            IList<TileControl> playerTiles = availableTiles.Take(_tilesPerPlayer).ToList();

            foreach(TileControl x in playerTiles)
            {
                x.Owner = playerName;
            }

            return playerTiles.ToList<Tile>();

        }

        public void Shuffle()
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            for(int i = 0; i < _pool.Count; i++)
            {
                _pool[i].Index = rnd.Next();
            }
        }

        public IList<TileControl> Tiles
        {
            get { return _pool.OrderBy(x => x.Index).ToList(); }
        }

    }
}
