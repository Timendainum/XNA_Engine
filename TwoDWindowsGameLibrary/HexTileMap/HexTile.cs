using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TwoDWindowsGameLibrary.HexTileMap
{
     public static class HexTile
    {
        public static Texture2D Texture;
	   public static int Width = 33;
	   public static int Height = 27;
	   public static int StepX = 52;
	   public static int StepY = 14;
	   public static int OddRowXOffset = 26;

	   public static Vector2 originPoint = new Vector2(19, 39);

	   public static Rectangle GetSourceRectangle(int tileIndex)
        {
            int tileY = tileIndex / (Texture.Width / Width);
            int tileX = tileIndex % (Texture.Width / Width);

            return new Rectangle(tileX * Width, tileY * Height, Width, Height);
        }

    }
}
