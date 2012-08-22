using System.Collections.Generic;

namespace TwoDWindowsGameLibrary.HexTileMap
{
    public class MapCell
    {
        public List<int> BaseTiles = new List<int>();

        public int TileId
        {
            get { return BaseTiles.Count > 0 ? BaseTiles[0] : 0; }
            set
            {
                if (BaseTiles.Count > 0)
                    BaseTiles[0] = value;
                else
                    AddBaseTile(value);
            }
        }

        public void AddBaseTile(int tileID)
        {
            BaseTiles.Add(tileID);
        }

        public MapCell(int tileID)
        {
            TileId = tileID;
        }
    }
}
