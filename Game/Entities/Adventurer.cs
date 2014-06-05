using System;
using System.Drawing;
using ISGPAI.Game.Artwork;
using ISGPAI.Game.Maths;
using ISGPAI.Game.SteeringBehaviors;

namespace ISGPAI.Game.Entities
{
	internal class Adventurer : MovingEntity
	{
		// In seconds.
		private const double AnimationInterval = 0.05;

		// If this entity's speed is below this value, it will stand still
		// (instead of showing the walking animation.
		private const double AnimationSpeedThreshold = 25;

		private const double Drag = 20;

		private ISteeringBehavior _steering;
		private AnimatedSpriteSet _spriteSet;

		// In seconds.
		private double _timeSinceLastAnimation;

		public Adventurer()
		{
			_steering = new KeyboardSteering();
			_spriteSet = new AnimatedSpriteSet("adventurer.png", 32, 64);
			Mass = 1;
			MaxSpeed = 400;
		}

		public override void Update(double elapsed)
		{
			Vector2 steeringForce = _steering.Steer(this, elapsed) * 2000;
			Vector2 acceleration = steeringForce / Mass;
			Velocity += acceleration * elapsed;
			Velocity = Velocity.Truncate(MaxSpeed);
			Position += Velocity * elapsed;
			if (acceleration.Length == 0)
			{
				if (Velocity.Length - Drag > 0)
				{
					Velocity = Velocity.Truncate(Velocity.Length - Drag);
				}
				else
				{
					Velocity = new Vector2();
				}
			}

			UpdateSpriteDirection();
			UpdateSpriteAnimation(elapsed);
		}

		private void UpdateSpriteDirection()
		{
			// Change the direction the sprite is facing depending on
			// the current velocity.
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

		private void UpdateSpriteAnimation(double elapsed)
		{
			if (Velocity.Length > AnimationSpeedThreshold)
			{
				double timeFactor = Velocity.Length / MaxSpeed;
				if (_timeSinceLastAnimation * timeFactor > AnimationInterval)
				{
					_timeSinceLastAnimation = 0;
					_spriteSet.AdvanceAnimation();
				}
				else
				{
					_timeSinceLastAnimation += elapsed;
				}
			}
			else
			{
				_spriteSet.ChangeColumn(1);
			}
		}

		public override void Paint(Graphics g)
		{
			_spriteSet.PaintAt(g, this.Position);
		}
	}
}
