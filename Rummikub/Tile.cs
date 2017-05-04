using System.Diagnostics;

namespace Rummikub
{
    [DebuggerDisplay("{Color}{Value}")]
    public class Tile
    {
        public TileColor Color { get; private set; } 
        public int Value { get; private set; }

        public Tile(TileColor color, int value)
        {
            this.Color = color;
            this.Value = value;
        }
    }

    public enum TileColor
    {
        Red = 1,
        Black = 2,
        Blue = 3,
        Orange = 4
    }
}
