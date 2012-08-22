using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TwoDWindowsGameLibrary.IsometricTileMap
{
    public class Tile
    {
        public Texture2D TileSetTexture;
        public int TileWidth = 64;
        public int TileHeight = 64;
        public int TileStepX = 64;
        public int TileStepY = 16;
        public int OddRowXOffset = 32;
        public int HeightTileOffset = 32;

        public Vector2 originPoint = new Vector2(19, 39);

        public Rectangle GetSourceRectangle(int tileIndex)
        {
            int tileY = tileIndex / (TileSetTexture.Width / TileWidth);
            int tileX = tileIndex % (TileSetTexture.Width / TileWidth);

            return new Rectangle(tileX * TileWidth, tileY * TileHeight, TileWidth, TileHeight);
        }
    }
}
