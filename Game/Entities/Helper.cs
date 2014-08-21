﻿using System;
using System.Drawing;
using ISGPAI.Game.Artwork;
using ISGPAI.Game.Maths;
using ISGPAI.Game.SteeringBehaviors;

namespace ISGPAI.Game.Entities
{
	public class Helper : MovingEntity
	{
		// In seconds.
		private const double AnimationInterval = 0.05;

		// If this entity's speed is below this value, it will stand still
		// (instead of showing the walking animation.
		private const double AnimationSpeedThreshold = 25;

		private World _world;
		private AnimatedSpriteSet _sprite;
		private SeekAtSteering _seekAt;
		private bool _isMoving;

		// In seconds.
		private double _timeSinceLastAnimation;

		public Helper(World world)
		{
			MaxSpeed = 200;
			Mass = 1;

			_sprite = new AnimatedSpriteSet("helper.png", 32, 64);
			_seekAt = new SeekAtSteering();
			_isMoving = false;
		}

		public override void Update(double elapsed)
		{
			if (_isMoving)
			{
				Move(elapsed);
			}
		}

		public override void Paint(Graphics g)
		{
			_sprite.PaintAt(g, this.Position);
		}

		public void MoveTo(Vector2 location)
		{
			_seekAt = new SeekAtSteering();
			_seekAt.Location = location;
			_isMoving = true;
		}

		public void StopMoving()
		{
			_isMoving = false;
		}

		private void Move(double elapsed)
		{
			Vector2 steeringForce = _seekAt.Steer(this, elapsed) * 8;
			Vector2 acceleration = steeringForce / this.Mass;
			this.Velocity += acceleration * elapsed;
			this.Velocity = this.Velocity.Truncate(this.MaxSpeed);
			this.Position += this.Velocity * elapsed;
		}

		private void UpdateSpriteDirection()
		{
			// Change the direction the sprite is facing depending on
			// the current velocity.
			if (Math.Abs(Velocity.X) > Math.Abs(Velocity.Y))
			{
				if (Velocity.X < 0)
				{
					_sprite.ChangeRow(2);
				}
				else
				{
					_sprite.ChangeRow(3);
				}
			}
			else
			{
				if (Velocity.Y < 0)
				{
					_sprite.ChangeRow(0);
				}
				else
				{
					_sprite.ChangeRow(1);
				}
			}
		}

		private void UpdateSpriteAnimation(double elapsed)
		{
			if (Velocity.Length > AnimationSpeedThreshold)
			{
				double timeFactor = Velocity.Length / 200;
				if (_timeSinceLastAnimation * timeFactor > AnimationInterval)
				{
					_timeSinceLastAnimation = 0;
					_sprite.AdvanceAnimation();
				}
				else
				{
					_timeSinceLastAnimation += elapsed;
				}
			}
			else
			{
				_sprite.ChangeColumn(1);
			}
		}
	}
}
