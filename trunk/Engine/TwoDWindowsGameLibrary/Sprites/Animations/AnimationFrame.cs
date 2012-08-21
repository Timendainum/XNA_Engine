using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TwoDWindowsGameLibrary.Sprites.Animiations
{
	public class AnimationFrame
	{
		#region Fields
		public Texture2D Texture;
		public Rectangle SourceRectangle;
		public float PlayTime = 0.0f;
		#endregion

		#region Constructors
		public AnimationFrame(Texture2D texture, Rectangle sourceRectangle, float playTime)
		{
			Texture = texture;
			SourceRectangle = sourceRectangle;
			PlayTime = playTime;
		}
		#endregion
	}
}
