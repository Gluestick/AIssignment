using System;

namespace ISGPAI.Game
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
	}
}
