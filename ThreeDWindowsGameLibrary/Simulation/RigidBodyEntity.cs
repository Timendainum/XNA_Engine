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
				return VectorHelper.ToXNAVector(Body.Position) - PositionOffset;
			}
			set
			{
				Body.Position = VectorHelper.ToJitterVector(value + PositionOffset);
			}
		}

		public override Matrix Rotation
		{
			get
			{
				return VectorHelper.ToXNAMatrix(Body.Orientation);
			}
			set
			{
				Body.Orientation = VectorHelper.ToJitterMatrix(value);
			}
		}
		
		
		
		public RigidBodyEntity(string name, Vector3 position, Matrix rotation, Vector3 scale, Shape shape)
			: base(name, scale)
		{
			Body = new RigidBody(shape);
			Body.EnableDebugDraw = true;
			Position = position;
			Rotation = rotation;
		}
	}
}
