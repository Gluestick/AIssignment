using ISGPAI.Game.Maths;

namespace ISGPAI.Game.Entities
{
	/// <summary>
	/// Abstract entity that allows implementations to move around the game world.
	/// </summary>
	abstract internal class MovingEntity : Entity
	{
		private Vector2 _velocity;
		private Vector2 _heading;
		private Vector2 _side;
		private double _mass;
		private double _maxSpeed;
		private double _maxForce;
		private double _maxTurnRate;

		public Vector2 Velocity
		{
			get { return _velocity; }
			set
			{
				_velocity = value;
				// Update heading and side with non zero velocity.
				if (_velocity.Length >= double.Epsilon)
				{
					_heading = Vector2.Normalize(_velocity);
					_side = _heading.Perpendicular();
				}
			}
		}

		public Vector2 Heading
		{
			get { return _heading; }
			set { _heading = value; }
		}

		public Vector2 Side
		{
			get { return _side; }
			set { _side = value; }
		}

		public double Mass
		{
			get { return _mass; }
			set { _mass = value; }
		}

		public double MaxSpeed
		{
			get { return _maxSpeed; }
			set { _maxSpeed = value; }
		}

		public double MaxForce
		{
			get { return _maxForce; }
			set { _maxForce = value; }
		}

		public double MaxTurnRate
		{
			get { return _maxTurnRate; }
			set { _maxTurnRate = value; }
		}
	}
}
