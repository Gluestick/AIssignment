namespace ISGPAI.Game.Maths
{
	public static class Transformation
	{
		/// <summary>
		/// Transforms a point from the agent's local space into world space.
		/// </summary>
		public static Vector2 PointToWorldSpace(
			Vector2 point,
			Vector2 agentHeading,
			Vector2 agentSide,
			Vector2 agentPosition)
		{
			Vector2 transformPoint = new Vector2(point);
			Matrix2 matrix = new Matrix2();
			matrix.Rotate(agentHeading, agentSide);
			matrix.Translate(agentPosition.X, agentPosition.Y);
			Vector2 result = matrix.Transform(transformPoint);
			return result;
		}
	}
}
