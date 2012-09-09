using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ClientWindowsGameLibrary.ScreenManagement
{
	public class ScreenContentManager
	{
		private Dictionary<string, SpriteFont> _Fonts = new Dictionary<string, SpriteFont>();
		private Dictionary<string, Texture2D> _Textures = new Dictionary<string, Texture2D>();
		private Dictionary<string, Model> _Models = new Dictionary<string, Model>();
		private Dictionary<string, Effect> _Effects = new Dictionary<string, Effect>();

		ContentManager _content;

		public ScreenContentManager(ContentManager content)
		{
			Unload();
			_content = content;
		}

		public void Unload()
		{
			_Fonts.Clear();
			_Textures.Clear();
			_Models.Clear();
		}

		public Texture2D GetTexture(string name)
		{
			return _Textures[name];
		}

		public void AddTexture(string name, string contentPath)
		{
			_Textures[name] = _content.Load<Texture2D>(contentPath);
		}

		public SpriteFont GetFont(string name)
		{
			return _Fonts[name];
		}

		public void AddFont(string name, string contentPath)
		{
			_Fonts[name] = _content.Load<SpriteFont>(contentPath);
		}

		public Model GetModel(string name)
		{
			return _Models[name];
		}

		public void AddModel(string name, string contentPath)
		{
			_Models[name] = _content.Load<Model>(contentPath);
		}

		public Effect GetEffect(string name)
		{
			return _Effects[name];
		}

		public void AddEffect(string name, string contentPath)
		{
			_Effects[name] = _content.Load<Effect>(contentPath);
		}

	}
}
