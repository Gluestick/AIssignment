using System;
using System.Drawing;
using ISGPAI.Game.Artwork;
using ISGPAI.Game.Maths;
using ISGPAI.Game.SteeringBehaviors;

namespace ISGPAI.Game.Entities
{
	internal class Adventurer : MovingEntity
	{
		// In milliseconds.
		private const int AnimationInterval = 500;

		private ISteeringBehavior _steering;
		private AnimatedSpriteSet _spriteSet;

		private TimeSpan _timeSinceLastAnimation;

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

			UpdateSprite();
		}

		private void UpdateSprite()
		{
			if (Math.Abs(Velocity.X) > Math.Abs(Velocity.Y))
			{
				if (Velocity.X < 0)
				{
					_spriteSet.ChangeRow(2);
				}
				else
				{
					_spriteSet.ChangeRow(3);
				}
			}
			else
			{
				if (Velocity.Y < 0)
				{
					_spriteSet.ChangeRow(0);
				}
				else
				{
					_spriteSet.ChangeRow(1);
				}
			}
		}

		public override void Paint(Graphics g)
		{
			_spriteSet.PaintAt(g, this.Position);
		}
	}
}
