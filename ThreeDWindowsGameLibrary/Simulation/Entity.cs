using Microsoft.Xna.Framework;
using ThreeDWindowsGameLibrary.Actors;

namespace ThreeDWindowsGameLibrary.Simulation
{
	public abstract class Entity
	{
		#region properties
		public abstract Vector3 Position { get; set; }

		public abstract Vector3 Rotation { get; set; }

		public Vector3 Scale { get; set; }

		public string Name { get; set; }
		#endregion


		public Entity(string name, Vector3 scale)
		{
			Name = name;
			Scale = scale;
		}

		//public abstract void Update(GameTime gameTime);
	}
}
