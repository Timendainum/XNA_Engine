using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThreeDWindowsGameLibrary.Cameras
{
	public class ArcBallCamera : Camera
	{
		// Rotation around the two axes
		public float RotationX { get; set; }

		private float _rotationY;
		public float RotationY
		{
			get
			{
				return _rotationY;
			}
			set
			{
				_rotationY = MathHelper.Clamp(value, MinRotationY, MaxRotationY);
			}
		}

		// Y axis rotation limits (radians)
		public float MinRotationY { get; set; }
		public float MaxRotationY { get; set; }

		// Distance between the target and camera
		private float _Distance;
		public float Distance
		{
			get
			{
				return _Distance;
			}
			set
			{
				_Distance = MathHelper.Clamp(value, MinDistance, MaxDistance);
			}
		}

		// Distance limits
		public float MinDistance { get; set; }
		public float MaxDistance { get; set; }

		// Calculated position and specified target
		public Vector3 Position { get; private set; }
		public Vector3 Target { get; set; }

		public ArcBallCamera(Vector3 target, float rotationX,
		    float rotationY, float minRotationY, float maxRotationY,
		    float distance, float minDistance, float maxDistance,
		    GraphicsDevice graphicsDevice)
			: base(graphicsDevice)
		{
			Target = target;

			MinRotationY = minRotationY;
			MaxRotationY = maxRotationY;

			// Lock the y axis rotation between the min and max values
			RotationY = rotationY;
			RotationX = rotationX;

			MinDistance = minDistance;
			MaxDistance = maxDistance;

			// Lock the distance between the min and max values
			Distance = distance;
		}

		public void Move(float distanceChange)
		{
			Distance += distanceChange;
		}

		public void Rotate(float rotationXChange, float rotationYChange)
		{
			RotationX += rotationXChange;
			RotationY += -rotationYChange;
		}

		public void Translate(Vector3 positionChange)
		{
			Position += positionChange;
		}

		public override void Update()
		{
			// Calculate rotation matrix from rotation values
			Matrix rotation = Matrix.CreateFromYawPitchRoll(RotationX, -RotationY, 0);

			// Translate down the Z axis by the desired distance
			// between the camera and object, then rotate that
			// vector to find the camera offset from the target
			Vector3 translation = new Vector3(0, 0, Distance);
			translation = Vector3.Transform(translation, rotation);

			Position = Target + translation;

			// Calculate the up vector from the rotation matrix
			Vector3 up = Vector3.Transform(Vector3.Up, rotation);

			View = Matrix.CreateLookAt(Position, Target, up);
		}
	}
}
