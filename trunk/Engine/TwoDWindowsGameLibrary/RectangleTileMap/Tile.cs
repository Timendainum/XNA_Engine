using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TwoDWindowsGameLibrary.RectangleTileMap
{
    public class Tile
    {
        public Texture2D Texture;
        public int Width = 48;
        public int Height = 48;

        public Vector2 originPoint = new Vector2(19, 39);

        public Rectangle GetSourceRectangle(int tileIndex)
        {
            int tileY = tileIndex / (Texture.Width / Width);
            int tileX = tileIndex % (Texture.Width / Width);

            return new Rectangle(tileX * Width, tileY * Height, Width, Height);
        }

    }
}
