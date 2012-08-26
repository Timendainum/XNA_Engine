using System.Collections.Generic;

namespace TwoDWindowsGameLibrary.RectangleTileMap
{
    public class RectangleTileMap
    {
        public List<MapRow> Rows = new List<MapRow>();
        public int Width;
        public int Height;

        public RectangleTileMap(int height, int width)
        {
		   Height = height;
		   Width = width;

            for (int y = 0; y < Height; y++)
            {
                MapRow thisRow = new MapRow();
                for (int x = 0; x < Width; x++)
                {
                    thisRow.Columns.Add(new MapCell(0));
                }
                Rows.Add(thisRow);
            }


        }
    }
}
