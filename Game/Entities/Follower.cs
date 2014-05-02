using System.Drawing;
using ISGPAI.Game.Maths;
using ISGPAI.Game.SteeringBehaviors;

namespace ISGPAI.Game.Entities
{
	/// <summary>
	/// Entity that arrives the specified target.
	/// </summary>
	internal class Follower : MovingEntity
	{
		private ArriveAtSteering _steering;
		private MovingEntity _target;

		public Follower(MovingEntity target, float distance)
		{
			MaxSpeed = 200;
			Mass = 1;
			this._target = target;
			this._steering = new ArriveAtSteering(target.Position, distance);
		}

		public override void Update(double elapsed)
		{
			_steering.Location = _target.Position;
			Vector2 steeringForce = _steering.Steer(this, elapsed) * 1000;
			Vector2 acceleration = steeringForce / Mass;
			Velocity += acceleration * elapsed;
			Velocity = Velocity.Truncate(MaxSpeed);
			Position += Velocity * elapsed;
		}

		public override void Paint(System.Drawing.Graphics g)
		{
			const int Size = 10;
			g.FillEllipse(Brushes.Red,
				(int)Position.X - Size / 2,
				(int)Position.Y - Size / 2,
				Size, Size
			);
		}
	}
}
