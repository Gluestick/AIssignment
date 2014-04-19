namespace ISGPAI.Game
{
	abstract internal class MovingEntity
	{
		protected Vector2 _velocity;
		protected Vector2 _heading;
		protected Vector2 _side;
		protected double _mass;
		protected double _maxSpeed;
		protected double _maxForce;
		protected double _maxTurnRate;
	}
}
