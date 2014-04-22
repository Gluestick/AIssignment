namespace ISGPAI.Game
{
	/// <summary>
	/// I don't know what's happening here. Ask the book.
	/// </summary>
	internal class Matrix2
	{
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

		public Vector2 Rotate(Vector2 agentHeading, Vector2 agentSide)
		{
			throw new System.NotImplementedException();
		}

		public Vector2 Translate(double x, double y)
		{
			throw new System.NotImplementedException();
		}
	}
}
