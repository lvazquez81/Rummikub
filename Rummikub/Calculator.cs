using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummikub
{
    public class Calculator
    {
        public static bool IsValid(IList<Tile> tiles)
        {
            return HasSameColor(tiles) && HasEnoughTiles(tiles) && HasNumberSequence(tiles);
        }

        private static bool HasNumberSequence(IList<Tile> tiles)
        {
            bool hasNumericSequence = true;

            IList<Tile> orderedTiles = (from x in tiles orderby x.Value ascending select x).ToList();

            int initialValue = orderedTiles[0].Value;

            for(int i = 0; i < tiles.Count; i++)
            {
                int expectedValue = i + initialValue;

                if(expectedValue != tiles[i].Value)
                {
                    hasNumericSequence = false;
                    break;
                }
            }

            return hasNumericSequence;

        }

        private static bool HasSameColor(IList<Tile> tiles)
        {
            TileColor groupColor = tiles[0].Color;

            int sameColorCount = (from x in tiles where x.Color == groupColor select x).Count();

            return sameColorCount == tiles.Count;
        }

        private static bool HasEnoughTiles(IList<Tile> tiles)
        {
            return tiles.Count >= 3;
        }
    }
}
