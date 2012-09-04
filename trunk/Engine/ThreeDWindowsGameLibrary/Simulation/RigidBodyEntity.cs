using Microsoft.Xna.Framework;
using System;
using Jitter.Collision.Shapes;
using Jitter.Dynamics;
using Jitter.LinearMath;

namespace ThreeDWindowsGameLibrary.Simulation
{
	public class RigidBodyEntity : Entity
	{
		public Shape Shape;
		public RigidBody Body;

		public override Vector3 Position
		{
			get
			{
				return VectorHelper.ToXNAVector(Body.Position);
			}
			set
			{
				Body.Position = VectorHelper.ToJitterVector(value);
			}
		}

		public override Vector3 Rotation
		{
			get
			{
				return VectorHelper.CreateRotationVector(VectorHelper.ToXNAMatrix(Body.Orientation));
			}
			set
			{
				Body.Orientation = VectorHelper.ToJitterMatrix(VectorHelper.CreateOrientationMatrix(value));
			}
		}
		
		
		
		public RigidBodyEntity(string name, Vector3 position, Vector3 rotation, Vector3 scale, Shape shape)
			: base(name, scale)
		{
			Body = new RigidBody(shape);

			Position = position;
			Rotation = rotation;
		}
	}
}
