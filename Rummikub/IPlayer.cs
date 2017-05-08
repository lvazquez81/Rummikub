using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummikub
{
    public interface IPlayer
    {
        bool Play(IList<Tile> tiles);
        Tile PickSpare();
    }
}
