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
		private ArriveAtSteering _arrive;
		private SeparationSteering _separate;
		private MovingEntity _target;

		public Follower(World world, MovingEntity target, float distance)
		{
			MaxSpeed = 250;
			Mass = 1;
			this._separate = new SeparationSteering(world, distance);
			this._target = target;
			this._arrive = new ArriveAtSteering(target.Position, distance);
		}

		public override void Update(double elapsed)
		{
			_arrive.Location = _target.Position;
			Vector2 steeringForce = _arrive.Steer(this, elapsed);
			steeringForce += _separate.Steer(this, elapsed) * 2;
			steeringForce *= 6;
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
