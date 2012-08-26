using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TwoDWindowsGameLibrary.RectangleTileMap;

namespace RectangleTileMapTestGame
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class RectangleTileMapTestGame : Microsoft.Xna.Framework.Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Dictionary<String, Texture2D> Textures = new Dictionary<String, Texture2D>();
		RectangleTileMap rtm;

		public RectangleTileMapTestGame()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "TestContent";
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
			Texture2D newTexture = Content.Load<Texture2D>(@"TileSets\part1_tileset");
			Textures.Add("TileMap", newTexture);


			rtm = new RectangleTileMap(50, 50);
			Tile.Height = 32;
			Tile.Width = 32;
			Tile.Texture = Textures["TileMap"];

			// Create Sample Map Data
			rtm.Rows[0].Columns[3].TileID = 3;
			rtm.Rows[0].Columns[4].TileID = 3;
			rtm.Rows[0].Columns[5].TileID = 1;
			rtm.Rows[0].Columns[6].TileID = 1;
			rtm.Rows[0].Columns[7].TileID = 1;

			rtm.Rows[1].Columns[3].TileID = 3;
			rtm.Rows[1].Columns[4].TileID = 1;
			rtm.Rows[1].Columns[5].TileID = 1;
			rtm.Rows[1].Columns[6].TileID = 1;
			rtm.Rows[1].Columns[7].TileID = 1;

			rtm.Rows[2].Columns[2].TileID = 3;
			rtm.Rows[2].Columns[3].TileID = 1;
			rtm.Rows[2].Columns[4].TileID = 1;
			rtm.Rows[2].Columns[5].TileID = 1;
			rtm.Rows[2].Columns[6].TileID = 1;
			rtm.Rows[2].Columns[7].TileID = 1;

			rtm.Rows[3].Columns[2].TileID = 3;
			rtm.Rows[3].Columns[3].TileID = 1;
			rtm.Rows[3].Columns[4].TileID = 1;
			rtm.Rows[3].Columns[5].TileID = 2;
			rtm.Rows[3].Columns[6].TileID = 2;
			rtm.Rows[3].Columns[7].TileID = 2;

			rtm.Rows[4].Columns[2].TileID = 3;
			rtm.Rows[4].Columns[3].TileID = 1;
			rtm.Rows[4].Columns[4].TileID = 1;
			rtm.Rows[4].Columns[5].TileID = 2;
			rtm.Rows[4].Columns[6].TileID = 2;
			rtm.Rows[4].Columns[7].TileID = 2;

			rtm.Rows[5].Columns[2].TileID = 3;
			rtm.Rows[5].Columns[3].TileID = 1;
			rtm.Rows[5].Columns[4].TileID = 1;
			rtm.Rows[5].Columns[5].TileID = 2;
			rtm.Rows[5].Columns[6].TileID = 2;
			rtm.Rows[5].Columns[7].TileID = 2;

			rtm.Rows[3].Columns[5].AddBaseTile(30);
			rtm.Rows[4].Columns[5].AddBaseTile(27);
			rtm.Rows[5].Columns[5].AddBaseTile(28);

			rtm.Rows[3].Columns[6].AddBaseTile(25);
			rtm.Rows[5].Columns[6].AddBaseTile(24);

			rtm.Rows[3].Columns[7].AddBaseTile(31);
			rtm.Rows[4].Columns[7].AddBaseTile(26);
			rtm.Rows[5].Columns[7].AddBaseTile(29);

			rtm.Rows[4].Columns[6].AddBaseTile(104);
			// End Create Sample Map Data

		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// Allows the game to exit
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
				this.Exit();

			// TODO: Add your update logic here

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin();

			Vector2 firstSquare = new Vector2(Camera.Location.X / Tile.Width, Camera.Location.Y / Tile.Height);
			int firstX = (int)firstSquare.X;
			int firstY = (int)firstSquare.Y;

			Vector2 squareOffset = new Vector2(Camera.Location.X % Tile.Width, Camera.Location.Y % Tile.Height);
			int offsetX = (int)squareOffset.X;
			int offsetY = (int)squareOffset.Y;

			for (int y = 0; y < rtm.Height; y++)
			{
				for (int x = 0; x < rtm.Width; x++)
				{
					spriteBatch.Draw(
					    Tile.Texture,
					    new Rectangle((x * 32) - offsetX, (y * 32) - offsetY, 32, 32),
					    Tile.GetSourceRectangle(rtm.Rows[y + firstY].Columns[x + firstX].TileID),
					    Color.White);
				}
			}

			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
