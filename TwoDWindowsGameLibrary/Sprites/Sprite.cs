using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TwoDWindowsGameLibrary.Sprites
{
    public class Sprite
    {
        #region Fields
        public Texture2D Texture;
		public Vector2 ScreenPosition;
		public Rectangle TextureSource;
		public Color TintColor = Color.White;
		public float Rotation = 0.0f;
		public Vector2 RelativeCenter = Vector2.Zero;
		public Vector2 Scale = new Vector2(1, 1);
		public SpriteEffects SpriteEffect = SpriteEffects.None;
		float LayerDepth = 0.0f;
        #endregion

		#region properties
		#endregion


		#region Constructors
		public Sprite(Vector2 screenPosition, Texture2D texture, Rectangle textureSource)
        {
			ScreenPosition = screenPosition;
			Texture = texture;
			TextureSource = textureSource;
		}
		#endregion

		#region Positional Properties
		
		#endregion

		#region Update and Draw Methods
		public virtual void Draw(SpriteBatch spriteBatch)
        {
			spriteBatch.Draw(
				Texture,
				ScreenPosition,
				TextureSource,
				TintColor,
				Rotation,
				RelativeCenter,
				Scale,
				SpriteEffect,
				LayerDepth);
        }

		public virtual void Update(GameTime gameTime)
		{
			return;
		}
        #endregion

    }
}
