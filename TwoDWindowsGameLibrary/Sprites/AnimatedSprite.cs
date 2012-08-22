using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TwoDWindowsGameLibrary.Sprites.Animiations;

namespace TwoDWindowsGameLibrary.Sprites
{
	public class AnimatedSprite : Sprite
	{
		public Dictionary<string, AnimationStrip> Animations = new Dictionary<string, AnimationStrip>();
		public string PlayingAnimation = string.Empty;
		public string NextAnimation = string.Empty;

		public AnimatedSprite(Vector2 screenPosition, Texture2D texture, Rectangle textureSource, string name, int frameCount, float fps)
		: base(screenPosition, texture, textureSource)
		{
			SetAnimation(name, texture, textureSource, frameCount, fps);
			PlayingAnimation = name;
		}

		public void SetAnimation(string name, Texture2D texture, Rectangle initialFrame, int frameCount, float fps)
		{
			Animations[name] = new AnimationStrip(texture, initialFrame, frameCount, fps);
		}

		public override void Update(GameTime gameTime)
		{
			Animations[PlayingAnimation].Update(gameTime);
		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
			AnimationStrip strip = Animations[PlayingAnimation];

			spriteBatch.Draw(
				strip.Frames[strip.CurrentFrame].Texture,
				ScreenPosition,
				strip.Frames[strip.CurrentFrame].SourceRectangle,
				TintColor,
				Rotation,
				RelativeCenter,
				Scale,
				SpriteEffect,
				LayerDepth);
		}
	}
}
