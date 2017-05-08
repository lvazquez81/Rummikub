using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rummikub
{
    public class TileProvider
    {
        public static IList<Tile> Create(string tilesString)
        {
            IList<Tile> tiles = new List<Tile>();

            if (!string.IsNullOrWhiteSpace(tilesString))
            {
                foreach (string tileString in tilesString.Split(',').Select(x => x.Trim()))
                {
                    string colorString = tileString[0].ToString();
                    string valueString = tileString.Substring(1, tileString.Length - 1).Trim();

                    TileColor? tileColor = ParseColor(colorString);
                    int? tileValue = ParseValue(valueString);

                    if (tileColor != null && tileValue != null)
                    {
                        tiles.Add(new Tile(tileColor.Value, tileValue.Value));
                    }
                }
            }

            return tiles;
        }

        public static object CreateTile(string tileString)
        {
            string colorString = tileString.Trim()[0].ToString();
            string valueString = tileString.Trim().Substring(1, tileString.Trim().Length - 1).Trim();

            TileColor? tileColor = ParseColor(colorString);
            int? tileValue = ParseValue(valueString);

            if (tileColor != null && tileValue != null)
            {
                return new Tile(tileColor.Value, tileValue.Value);
            }
            else
            {
                return null;
            }
        }

        private static int? ParseValue(string valueString)
        {
            int tileValue = -1;
            if (!int.TryParse(valueString, out tileValue))
            {
                return null;
            }
            else
            {
                return tileValue;
            }
        }

        private static TileColor? ParseColor(string colorString)
        {
            switch (colorString)
            {
                case "R": return TileColor.Red;
                case "G": return TileColor.Green;
                case "B": return TileColor.Blue;
                case "O": return TileColor.Orange;
                default: return null;
            }
        }

        public static string ToString(IList<Tile> tiles)
        {
            var tileString = new StringBuilder();

            for (int i = 0; i < tiles.Count; i++)
            {
                tileString.Append(tiles[i].ToString());

                if (i != tiles.Count)
                {
                    tileString.Append(",");
                }
            }
            return tileString.ToString();
        }
    }
}
