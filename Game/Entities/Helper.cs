using System;
using System.Drawing;
using ISGPAI.Game.Artwork;
using ISGPAI.Game.Entities.GoalDrivenBehavior;
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
		private ISteeringBehavior _steering;
		private bool _isSteering;
		private HelperThinkGoal _goal;

		// In seconds.
		private double _timeSinceLastAnimation;

		public bool IsVisible { get; set; }

		public Helper(World world)
		{
			MaxSpeed = 200;
			Mass = 1;
			IsVisible = true;

			_sprite = new AnimatedSpriteSet("helper.png", 32, 64);
			_isSteering = false;
			_world = world;
			_goal = new HelperThinkGoal(this, _world);
		}

		public override void Update(double elapsed)
		{
			if (_isSteering)
			{
				Steer(elapsed);
			}
			_goal.Process();
			UpdateSpriteDirection();
			UpdateSpriteAnimation(elapsed);
		}

		public override void Paint(Graphics g)
		{
			if (IsVisible)
			{
				_sprite.PaintAt(g, this.Position);
			}
			_goal.DrawDebugText(g, (float)Position.X + 25, (float)Position.Y - 25);
		}

		public void StopMovement()
		{
			Velocity = new Vector2();
		}

		public void SetSteering(ISteeringBehavior steering)
		{
			_steering = steering;
			_isSteering = true;
		}

		public void StopSteering()
		{
			_isSteering = false;
		}

		private void Steer(double elapsed)
		{
			Vector2 steeringForce = _steering.Steer(this, elapsed) * 8;
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
