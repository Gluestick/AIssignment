namespace ISGPAI.Game
{
	/// <summary>
	/// I don't know what's happening here. Ask the book.
	/// </summary>
	internal class Matrix2
	{
		private Matrix _matrix;

		public Matrix2()
		{
			_matrix = new Matrix();

			_matrix._11 = 1;
			_matrix._12 = 0;
			_matrix._13 = 0;

			_matrix._21 = 0;
			_matrix._22 = 1;
			_matrix._23 = 0;

			_matrix._31 = 0;
			_matrix._32 = 0;
			_matrix._33 = 1;
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
			double x =
				(_matrix._11 * transformPoint.X) +
				(_matrix._21 * transformPoint.Y) +
				_matrix._31;
			double y =
				(_matrix._12 * transformPoint.X) +
				(_matrix._22 * transformPoint.Y) +
				_matrix._32;

			return new Vector2(x, y);
		}

		private void MatrixMultiply(Matrix mat)
		{
			Matrix tmpMatrix = new Matrix();

			// First row
			tmpMatrix._11 =
				(_matrix._11 * mat._11) +
				(_matrix._12 * mat._21) +
				(_matrix._13 * mat._31);

			tmpMatrix._12 =
				(_matrix._11 * mat._12) +
				(_matrix._12 * mat._22) +
				(_matrix._13 * mat._32);

			tmpMatrix._13 =
				(_matrix._11 * mat._13) +
				(_matrix._12 * mat._23) +
				(_matrix._13 * mat._33);

			// Second row
			tmpMatrix._21 =
				(_matrix._21 * mat._11) +
				(_matrix._22 * mat._21) +
				(_matrix._23 * mat._31);

			tmpMatrix._22 =
				(_matrix._21 * mat._12) +
				(_matrix._22 * mat._22) +
				(_matrix._23 * mat._32);

			tmpMatrix._23 =
				(_matrix._21 * mat._13) +
				(_matrix._22 * mat._23) +
				(_matrix._23 * mat._33);

			// Third row
			tmpMatrix._31 =
				(_matrix._31 * mat._11) +
				(_matrix._32 * mat._21) +
				(_matrix._33 * mat._31);

			tmpMatrix._32 =
				(_matrix._31 * mat._12) +
				(_matrix._32 * mat._22) +
				(_matrix._33 * mat._32);

			tmpMatrix._33 =
				(_matrix._31 * mat._13) +
				(_matrix._32 * mat._23) +
				(_matrix._33 * mat._33);

			_matrix = tmpMatrix;
		}
	}
}
