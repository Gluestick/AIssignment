using System.Drawing;
using ISGPAI.Game.SteeringBehaviors;

namespace ISGPAI.Game.Entities
{
	internal class Adventurer : MovingEntity
	{
		private ISteeringBehavior _steering;

		public Adventurer()
		{
			_steering = new KeyboardSteering(0.00001);
			Mass = 75;
			MaxSpeed = 0.0001;
		}

		public override void Update(double elapsed)
		{
			Vector2 steeringForce = _steering.Steer(this);
			Vector2 acceleration = steeringForce / Mass;
			Velocity += acceleration * elapsed;
			Velocity = Velocity.Truncate(MaxSpeed);
			Position += Velocity * elapsed;
		}

		public override void Paint(Graphics g)
		{
			const int Size = 20;
			g.FillEllipse(Brushes.Black,
				(int)Position.X - Size / 2,
				(int)Position.Y - Size / 2,
				Size, Size
			);
		}
	}
}
