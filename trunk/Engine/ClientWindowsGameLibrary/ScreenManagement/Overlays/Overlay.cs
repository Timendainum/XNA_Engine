﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClientWindowsGameLibrary.ScreenManagement.Overlays
{
	public abstract class Overlay
	{
		public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
		public abstract void HandleInput(InputState input);
		public abstract void Update(GameTime gameTime);
		

		public bool IsActive = false;

		public Vector2 ScreenPosition;
		
		public int Height;
		public int Width;

		private GameScreen _screen;

		public GameScreen Screen
		{
			get
			{
				return _screen;
			}
			private set
			{
				_screen = value;
			}
		}
		public Vector2 RelativeCenter
		{
			get
			{
				return new Vector2(Width / 2, Height / 2);
			}
		}

		public Vector2 ScreenCenter
		{
			get
			{
				return RelativeCenter + ScreenPosition;
			}
		}


		public Overlay(GameScreen screen)
		{
			_screen = screen;
		}

		public void ToggleActive()
		{
			if (IsActive)
				IsActive = false;
			else
				IsActive = true;
		}

		public Rectangle GetScreenRectangle()
		{
			return new Rectangle((int)ScreenPosition.X, (int)ScreenPosition.Y, Width, Height);
		}
		public Rectangle GetWorldRectangle()
		{
			return new Rectangle((int)ScreenPosition.X, (int)ScreenPosition.Y, Width, Height);
		}

		public Vector2 TransformScreenToOverlay(Vector2 point)
		{
			return point - ScreenPosition;
		}

		public Vector2 TransformOverlayToScreen(Vector2 point)
		{
			return ScreenPosition + point;
		}


	}
}
