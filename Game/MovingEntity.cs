namespace ISGPAI.Game
{
	abstract internal class MovingEntity
	{
		private Vector2 _velocity;
		private Vector2 _heading;
		private Vector2 _side;
		private double _mass;
		private double _maxSpeed;
		private double _maxForce;
		private double _maxTurnRate;
	}
}
