using System.Collections.Generic;

namespace Rummikub
{
    public class Player
    {
        public string Name { get; private set; }
        public IList<Tile> Tiles { get; set; }
        public int Order { get; set; }

        public Player(string name)
        {
            this.Name = name;
        }
    }
}
