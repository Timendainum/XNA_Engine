using System.Collections.Generic;

namespace TwoDWindowsGameLibrary.HexTileMap
{
    public class HexTileMap
    {
        public List<MapRow> Rows = new List<MapRow>();
        public int Width = 50;
        public int Height = 50;

        public HexTileMap()
        {
            for (int y = 0; y < Height; y++)
            {
                MapRow thisRow = new MapRow();
                for (int x = 0; x < Width; x++)
                {
                    thisRow.Columns.Add(new MapCell(0));
                }
                Rows.Add(thisRow);
            }

            // Create Sample Map Data
            Rows[0].Columns[3].TileId = 3;
            Rows[0].Columns[4].TileId = 3;
            Rows[0].Columns[5].TileId = 1;
            Rows[0].Columns[6].TileId = 1;
            Rows[0].Columns[7].TileId = 1;

            Rows[1].Columns[3].TileId = 3;
            Rows[1].Columns[4].TileId = 1;
            Rows[1].Columns[5].TileId = 1;
            Rows[1].Columns[6].TileId = 1;
            Rows[1].Columns[7].TileId = 1;

            Rows[2].Columns[2].TileId = 3;
            Rows[2].Columns[3].TileId = 1;
            Rows[2].Columns[4].TileId = 1;
            Rows[2].Columns[5].TileId = 1;
            Rows[2].Columns[6].TileId = 1;
            Rows[2].Columns[7].TileId = 1;

            Rows[3].Columns[2].TileId = 3;
            Rows[3].Columns[3].TileId = 1;
            Rows[3].Columns[4].TileId = 1;
            Rows[3].Columns[5].TileId = 2;
            Rows[3].Columns[6].TileId = 2;
            Rows[3].Columns[7].TileId = 2;

            Rows[4].Columns[2].TileId = 3;
            Rows[4].Columns[3].TileId = 1;
            Rows[4].Columns[4].TileId = 1;
            Rows[4].Columns[5].TileId = 2;
            Rows[4].Columns[6].TileId = 2;
            Rows[4].Columns[7].TileId = 2;

            Rows[5].Columns[2].TileId = 3;
            Rows[5].Columns[3].TileId = 1;
            Rows[5].Columns[4].TileId = 1;
            Rows[5].Columns[5].TileId = 2;
            Rows[5].Columns[6].TileId = 2;
            Rows[5].Columns[7].TileId = 2;

            //Rows[3].Columns[5].AddBaseTile(30);
            //Rows[4].Columns[5].AddBaseTile(27);
            //Rows[5].Columns[5].AddBaseTile(28);

            //Rows[3].Columns[6].AddBaseTile(25);
            //Rows[5].Columns[6].AddBaseTile(24);

            //Rows[3].Columns[7].AddBaseTile(31);
            //Rows[4].Columns[7].AddBaseTile(26);
            //Rows[5].Columns[7].AddBaseTile(29);

            //Rows[4].Columns[6].AddBaseTile(104);
            // End Create Sample Map Data
        }
    }
}
