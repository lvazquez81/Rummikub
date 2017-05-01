using System.Diagnostics;

namespace Rummikub
{
    [DebuggerDisplay("{Index}:{Color}{Value}")]
    public class Tile
    {
        public TileColor Color { get; private set; } 
        public int Value { get; private set; }
        public int Index { get; private set; }

        public Tile(TileColor color, int value, int index)
        {
            this.Color = color;
            this.Value = value;
            this.Index = index;
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
