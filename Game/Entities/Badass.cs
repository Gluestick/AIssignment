using System;
using System.Drawing;
using ISGPAI.Game.Artwork;

namespace ISGPAI.Game.Entities
{
	public class Badass : MovingEntity
	{
		// In seconds.
		private const double AnimationInterval = 0.05;

		// If this entity's speed is below this value, it will stand still
		// (instead of showing the walking animation.
		private const double AnimationSpeedThreshold = 25;

		private const double Drag = 2000;
		private const double NavigationDistance = 12;

		private World _world;
		private AnimatedSpriteSet _spriteSet;

		// In seconds.
		private double _timeSinceLastAnimation;

		public Badass(World world)
		{
			this._spriteSet = new AnimatedSpriteSet("badass.png", 32, 64);
			this._world = world;
			Mass = 1;
			MaxSpeed = 400;
		}

		public override void Update(double elapsed)
		{
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