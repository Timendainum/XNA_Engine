using Jitter.LinearMath;
using Microsoft.Xna.Framework;
using System;

namespace ThreeDWindowsGameLibrary.Simulation
{
	public static class VectorHelper
	{
		public static JVector ToJitterVector(Vector3 vector)
		{
			return new JVector(vector.X, vector.Y, vector.Z);
		}

		public static Matrix ToXNAMatrix(JMatrix matrix)
		{
			return new Matrix(matrix.M11,
						 matrix.M12,
						 matrix.M13,
						 0.0f,
						 matrix.M21,
						 matrix.M22,
						 matrix.M23,
						 0.0f,
						 matrix.M31,
						 matrix.M32,
						 matrix.M33,
						 0.0f, 0.0f, 0.0f, 0.0f, 1.0f);
		}

		public static JMatrix ToJitterMatrix(Matrix matrix)
		{
			JMatrix result;
			result.M11 = matrix.M11;
			result.M12 = matrix.M12;
			result.M13 = matrix.M13;
			result.M21 = matrix.M21;
			result.M22 = matrix.M22;
			result.M23 = matrix.M23;
			result.M31 = matrix.M31;
			result.M32 = matrix.M32;
			result.M33 = matrix.M33;
			return result;

		}


		public static Vector3 ToXNAVector(JVector vector)
		{
			return new Vector3(vector.X, vector.Y, vector.Z);
		}

		public static Matrix CreateOrientationMatrix(Vector3 vector)
		{
			return Matrix.CreateFromYawPitchRoll(vector.Y, vector.X, vector.Z);
		}

		public static Vector3 CreateRotationVector(Matrix matrix)
		{
			return RadiansToDegrees(MatrixToEulerAngleVector3(matrix));
		}


		// Returns Euler angles that point from one point to another
		public static Vector3 AngleTo(Vector3 from, Vector3 location)
		{
			Vector3 angle = new Vector3();
			Vector3 v3 = Vector3.Normalize(location - from);

			angle.X = (float)Math.Asin(v3.Y);
			angle.Y = (float)Math.Atan2((double)-v3.X, (double)-v3.Z);

			return angle;
		}

		// Converts a Quaternion to Euler angles (X = Yaw, Y = Pitch, Z = Roll)
		public static Vector3 QuaternionToEulerAngleVector3(Quaternion rotation)
		{
			Vector3 rotationaxes = new Vector3();
			Vector3 forward = Vector3.Transform(Vector3.Forward, rotation);
			Vector3 up = Vector3.Transform(Vector3.Up, rotation);

			rotationaxes = AngleTo(new Vector3(), forward);

			if (rotationaxes.X == MathHelper.PiOver2)
			{
				rotationaxes.Y = (float)Math.Atan2((double)up.X, (double)up.Z);
				rotationaxes.Z = 0;
			}
			else if (rotationaxes.X == -MathHelper.PiOver2)
			{
				rotationaxes.Y = (float)Math.Atan2((double)-up.X, (double)-up.Z);
				rotationaxes.Z = 0;
			}
			else
			{
				up = Vector3.Transform(up, Matrix.CreateRotationY(-rotationaxes.Y));
				up = Vector3.Transform(up, Matrix.CreateRotationX(-rotationaxes.X));

				rotationaxes.Z = (float)Math.Atan2((double)-up.Z, (double)up.Y);
			}

			return rotationaxes;
		}

		// Converts a Rotation Matrix to a quaternion, then into a Vector3 containing
		// Euler angles (X: Pitch, Y: Yaw, Z: Roll)
		public static Vector3 MatrixToEulerAngleVector3(Matrix Rotation)
		{
			Vector3 translation, scale;
			Quaternion rotation;

			Rotation.Decompose(out scale, out rotation, out translation);

			Vector3 eulerVec = QuaternionToEulerAngleVector3(rotation);

			return eulerVec;
		}

		public static Vector3 RadiansToDegrees(Vector3 Vector)
		{
			return new Vector3(
			    MathHelper.ToDegrees(Vector.X),
			    MathHelper.ToDegrees(Vector.Y),
			    MathHelper.ToDegrees(Vector.Z));
		}

		public static Vector3 DegreesToRadians(Vector3 Vector)
		{
			return new Vector3(
			    MathHelper.ToRadians(Vector.X),
			    MathHelper.ToRadians(Vector.Y),
			    MathHelper.ToRadians(Vector.Z));
		}
	}

}
