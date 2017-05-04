using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummikub
{
    [DebuggerDisplay("{Index}:{Color}{Value}({Owner})")]
    public class TileControl : Tile
    {
        public int Index { get; set; }
        public string Owner { get; set; }

        public TileControl(TileColor color, int value, int index) 
            : base(color, value)
        {
            this.Index = index;
            this.Owner = null;
        }
    }
}
