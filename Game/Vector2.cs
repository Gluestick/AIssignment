namespace ISGPAI.Game
{
	/// <summary>
	/// 2 Dimensional vector.
	/// </summary>
	internal struct Vector2
	{
		public double X { get { return _x; } set { _x = value; } }
		public double Y { get { return _y; } set { _y = value; } }

		private double _x;
		private double _y;

		/// <summary>
		/// Creats a 2D vector with X and Y initialized to the specified values.
		/// </summary>
		public Vector2(double x, double y)
		{
			this._x = x;
			this._y = y;
		}
	}
}
