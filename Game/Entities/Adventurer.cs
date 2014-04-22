using System.Drawing;
using ISGPAI.Game.Maths;
using ISGPAI.Game.SteeringBehaviors;

namespace ISGPAI.Game.Entities
{
	internal class Adventurer : MovingEntity
	{
		private ISteeringBehavior _steering;

		public Adventurer()
		{
			_steering = new KeyboardSteering();
			Mass = 1;
			MaxSpeed = 400;
		}

		public override void Update(double elapsed)
		{
			Vector2 steeringForce = _steering.Steer(this, elapsed) * 1000;
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
