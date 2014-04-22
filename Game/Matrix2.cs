namespace ISGPAI.Game
{
	/// <summary>
	/// I don't know what's happening here. Ask the book.
	/// </summary>
	internal class Matrix2
	{
		private Matrix _matrix;

		private double _11;
		private double _12;
		private double _13;

		private double _21;
		private double _22;
		private double _23;

		private double _31;
		private double _32;
		private double _33;

		public Matrix2()
		{
			_matrix = new Matrix();

			_11 = 1;
			_12 = 0;
			_13 = 0;

			_21 = 0;
			_22 = 1;
			_23 = 0;

			_31 = 0;
			_32 = 0;
			_33 = 1;
		}

		public void Rotate(Vector2 forward, Vector2 side)
		{
			Matrix mat = new Matrix();
			mat._11 = forward.X;
			mat._12 = forward.Y;
			mat._13 = 0;

			mat._21 = side.X;
			mat._22 = side.Y;
			mat._23 = 0;

			mat._31 = 0;
			mat._32 = 0;
			mat._33 = 1;
			MatrixMultiply(mat);
		}

		public void Translate(double x, double y)
		{
			Matrix mat = new Matrix();

			mat._11 = 1;
			mat._12 = 0;
			mat._13 = 0;

			mat._21 = 0;
			mat._22 = 1;
			mat._23 = 0;

			mat._31 = x;
			mat._32 = y;
			mat._33 = 1;

			MatrixMultiply(mat);
		}

		public Vector2 Transform(Vector2 transformPoint)
		{
			throw new System.NotImplementedException();
		}

		private void MatrixMultiply(Matrix mat)
		{
		}
	}
}
