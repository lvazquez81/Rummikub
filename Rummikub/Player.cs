using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummikub
{
    public class Player
    {
        public string Name { get; private set; }
        public IList<Tile> Tiles { get; private set; }

        public Player(string name, IList<Tile> tiles)
        {
            this.Name = name;
            this.Tiles = tiles;
        }
    }
}
