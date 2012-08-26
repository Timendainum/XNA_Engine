using System.Collections.Generic;

namespace TwoDWindowsGameLibrary.HexTileMap
{
    public class HexTileMap
    {
        public List<MapRow> Rows = new List<MapRow>();
        public int Width;
        public int Height;

        public HexTileMap(int width, int height)
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
