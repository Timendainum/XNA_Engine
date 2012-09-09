using Microsoft.Xna.Framework;

namespace ThreeDWindowsGameLibrary.Simulation
{
	public abstract class Entity
	{
		#region properties
		public abstract Vector3 Position { get; set; }

		private Vector3 _positionOffset = Vector3.Zero;
		public Vector3 PositionOffset
		{
			get
			{
				return _positionOffset;
			}
			set
			{
				_positionOffset = value;
			}
		}

		public abstract Matrix Rotation { get; set; }

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
