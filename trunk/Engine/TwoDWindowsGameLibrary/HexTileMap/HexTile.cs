using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TwoDWindowsGameLibrary.HexTileMap
{
     public class HexTile
    {
        public Texture2D Texture;
        public int Width = 33;
        public int Height = 27;
        public int StepX = 52;
        public int StepY = 14;
        public int OddRowXOffset = 26;

        public Vector2 originPoint = new Vector2(19, 39);

        public Rectangle GetSourceRectangle(int tileIndex)
        {
            int tileY = tileIndex / (Texture.Width / Width);
            int tileX = tileIndex % (Texture.Width / Width);

            return new Rectangle(tileX * Width, tileY * Height, Width, Height);
        }

    }
}
