using System;
using System.Collections.Generic;

namespace Rummikub
{
    public class RummikubGame
    {
        private IDictionary<string, Player> _players;
        private TilePool _tilePool;

        public RummikubGame()
        {
            _players = new Dictionary<string, Player>();
            _tilePool = new TilePool(tilesPerColor: 13, jokerTiles: 2);
        }

        public void Initialize(params string[] playerNames)
        {
            foreach (string name in playerNames)
            {
                IList<Tile> tiles = _tilePool.GetInitialTiles();
                _players.Add(name, new Player(name, tiles));
            }
        }

        public Player CreatePlayer(string playerName)
        {
            throw new NotImplementedException();
        }

        public Player GetPlayer(string playerName)
        {
            if (_players.Keys.Contains(playerName))
            {
                return _players[playerName];
            }
            else
            {
                return null;
            }
        }
    }
}
