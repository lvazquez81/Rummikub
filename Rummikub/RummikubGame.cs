using System;
using System.Linq;
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

        public Player CreatePlayer(string playerName)
        {
            return new Player(playerName);
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

        public bool Play(Player player, string tilesString)
        {
            IList<Tile> playingTiles = TileProvider.Create(tilesString);

            if (IsValidGroup(playingTiles))
            {
                MoveTilesToBoard(playingTiles);
            }

            return true;
        }

        private void MoveTilesToBoard(IList<Tile> playingTiles)
        {
            throw new NotImplementedException();
        }

        private bool IsValidGroup(IList<Tile> playingTiles)
        {
            return Calculator.IsValid(playingTiles);
        }

        public void SetupGame(params Player[] players)
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            foreach (Player p in players)
            {
                p.Order = rnd.Next();

                _players.Add(p.Name, p);
            }
        }

        public IList<string> Players
        {
            get
            {
                return (from x in _players.Values
                        orderby x.Order ascending
                        select x.Name).ToList();
            }
        }

        public void GetInitialTiles(Player p)
        {
            p.Tiles = _tilePool.GetInitialTiles(p.Name);
        }
    }
}
