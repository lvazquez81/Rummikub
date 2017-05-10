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
            bool hasValidSequence = HasSameColor(tiles) && HasEnoughTiles(tiles) && HasNumberSequence(tiles);
            bool hasValidMirror = !HasSameColor(tiles) && HasEnoughTiles(tiles) && HasSameValue(tiles) && !HasDuplicateColors(tiles);
            return hasValidSequence || hasValidMirror;
        }

        private static bool HasDuplicateColors(IList<Tile> tiles)
        {
            TileColor groupColor = tiles[0].Color;

            // Find duplicate color tiles
            int duplicateColorCount = (from x in tiles group x by x.Color into y where y.Count() > 1 select y).Count();

            return duplicateColorCount > 0;
        }

        private static bool HasSameValue(IList<Tile> tiles)
        {
            int groupValue= tiles[0].Value;

            int sameGroupValue = (from x in tiles where x.Value== groupValue select x).Count();

            return sameGroupValue == tiles.Count;
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
