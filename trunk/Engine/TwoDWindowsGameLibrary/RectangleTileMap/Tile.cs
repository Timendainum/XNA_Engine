using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TwoDWindowsGameLibrary.RectangleTileMap
{
	public static class Tile
	{
		public static Texture2D Texture = null;
		public static int Width = 0;
		public static int Height = 0;

		public static Vector2 originPoint = Vector2.Zero;

		public static Rectangle GetSourceRectangle(int tileIndex)
		{
			int tileY;
			int tileX;

			try
			{
				tileY = tileIndex / (Texture.Width / Width);
				tileX = tileIndex % (Texture.Width / Width);
			}
			catch
			{
				//
				tileX = 0;
				tileY = 0;
			}


			return new Rectangle(tileX * Width, tileY * Height, Width, Height);
		}

	}
}
