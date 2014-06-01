using System.Drawing;
using ISGPAI.Game.Artwork;
using ISGPAI.Game.Maths;
using ISGPAI.Game.SteeringBehaviors;

namespace ISGPAI.Game.Entities
{
	internal class Adventurer : MovingEntity
	{
		private ISteeringBehavior _steering;
		private AnimatedSpriteSet _spriteSet;

		public Adventurer()
		{
			_steering = new KeyboardSteering();
			_spriteSet = new AnimatedSpriteSet("adventurer.png", 16, 32);
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
			_spriteSet.PaintAt(g, this.Position);
		}
	}
}
