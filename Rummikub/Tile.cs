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

        public override string ToString()
        {
            return string.Format("{0}{1}", this.Color.ToString()[0], this.Value);
        }
    }

    public enum TileColor
    {
        Red = 1,
        Green = 2,
        Blue = 3,
        Orange = 4
    }
}
