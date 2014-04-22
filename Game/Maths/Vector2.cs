using System;

namespace ISGPAI.Game.Maths
{
	/// <summary>
	/// 2 Dimensional vector.
	/// </summary>
	internal struct Vector2
	{
		private double _x;
		private double _y;

		public double X { get { return _x; } set { _x = value; } }
		public double Y { get { return _y; } set { _y = value; } }

		/// <summary>
		/// Gets the length of the vector.
		/// </summary>
		public double Length
		{
			get
			{
				// Pythagorean theorem.
				return Math.Sqrt(X * X + Y * Y);
			}
		}

		/// <summary>
		/// Creats a 2D vector with X and Y initialized to the specified values.
		/// </summary>
		public Vector2(double x, double y)
		{
			this._x = x;
			this._y = y;
		}

		/// <summary>
		/// Copies a vector to a new instance.
		/// </summary>
		public Vector2(Vector2 vector)
		{
			this._x = vector._x;
			this._y = vector._y;
		}

		/// <summary>
		/// Truncates the vector to the specified length. Does nothing if the
		/// vector's length is shorter than the specified length.
		/// </summary>
		public Vector2 Truncate(double length)
		{
			Vector2 result = new Vector2(_x, _y);
			double factor = this.Length / length;
			if (factor > 1)
			{
				result.X /= factor;
				result.Y /= factor;
			}
			return result;
		}

		/// <summary>
		/// Returns a vector that points in the same direction, but with
		/// a length of 1.
		/// </summary>
		public static Vector2 Normalize(Vector2 v)
		{
			Vector2 result = new Vector2(v.X, v.Y);
			double vectorLength = v.Length;
			if (vectorLength > Double.Epsilon)
			{
				result.X /= vectorLength;
				result.Y /= vectorLength;
			}
			return result;
		}

		/// <summary>
		/// Multiply the components of two vectors with eachother.
		/// </summary>
		public static Vector2 operator *(Vector2 a, Vector2 b)
		{
			return new Vector2(
				a.X * b.X,
				a.Y * b.Y
			);
		}

		/// <summary>
		/// Add the components of two vectors with eachother.
		/// </summary>
		public static Vector2 operator +(Vector2 a, Vector2 b)
		{
			return new Vector2(
				a.X + b.X,
				a.Y + b.Y
			);
		}

		/// <summary>
		/// Subtract the components of two vectors with eachother.
		/// </summary>
		public static Vector2 operator -(Vector2 a, Vector2 b)
		{
			return new Vector2(
				a.X - b.X,
				a.Y - b.Y
			);
		}

		/// <summary>
		/// Multiply the two components of the vector with the double value.
		/// </summary>
		public static Vector2 operator *(Vector2 v, double d)
		{
			return new Vector2(
				v.X * d,
				v.Y * d
			);
		}

		/// <summary>
		/// Multiply the two components of the vector with the double value.
		/// </summary>
		public static Vector2 operator *(double d, Vector2 v)
		{
			// Copy pasta kills kittens :(. Call other operator instead.
			return v * d;
		}

		/// <summary>
		/// Divide the two components of the vector with the double value.
		/// </summary>
		public static Vector2 operator /(Vector2 v, double d)
		{
			return new Vector2(
				v.X / d,
				v.Y / d
			);
		}

		/// <summary>
		/// Returns a new vector perpendicular to this vector.
		/// </summary>
		public Vector2 Perpendicular()
		{
			return new Vector2(-_y, _x);
		}
	}
}
