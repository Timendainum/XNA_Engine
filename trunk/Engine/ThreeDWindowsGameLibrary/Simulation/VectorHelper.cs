using Jitter.LinearMath;
using Microsoft.Xna.Framework;

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
			Matrix result = Matrix.Identity;
			result *= Matrix.CreateRotationX(vector.X);
			result *= Matrix.CreateRotationY(vector.Y);
			result *= Matrix.CreateRotationZ(vector.Z);

			return result;
		}

		public static Vector3 CreateRotationVector(Matrix matrix)
		{
			Quaternion q = Quaternion.CreateFromRotationMatrix(matrix);
			return new Vector3(q.X, q.Y, q.Z);
		}
	}
}
