using System;
using System.Drawing;
using System.Linq;
using ISGPAI.Game.Artwork;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game.Entities
{
	public class Creeper : MovingEntity, IStateChangeable<Creeper>
	{
		public const int Sight = 250;

		public int Health;

		// In seconds.
		private const double AnimationInterval = 0.05;

		// If this entity's speed is below this value, it will stand still
		// (instead of showing the walking animation.
		private const double AnimationSpeedThreshold = 25;

		private AnimatedSpriteSet _spriteSet;
		private World _world;
		private StateMachine<Creeper> _stateMachine;

		// In seconds.
		private double _timeSinceLastAnimation;

		public Creeper(Vector2 position, World world)
		{
			Position = position;
			this._spriteSet = new AnimatedSpriteSet("badass.png", 32, 64);
			Health = 100;
			Mass = 1;
			MaxSpeed = 200;
			Velocity = new Vector2(MaxSpeed, 0);
			// Wandering is the default state.
			this._world = world;
			this._stateMachine = new StateMachine<Creeper>(
				this, new CreeperSeeking(this, _world.Entities.First(), _world));
		}

		public void ChangeState(State<Creeper> newState)
		{
			_stateMachine.ChangeState(newState);
		}

		public override void Update(double elapsed)
		{
			if (Health > 0)
			{
				_stateMachine.Update(elapsed);
				UpdateSpriteDirection();
				UpdateSpriteAnimation(elapsed);
			}
			else
			{
				_world.RemoveEntity(this);
				_world.AddEntity(new CreeperExplosion(_world, Position));
			}
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
				double timeFactor = Velocity.Length / 200;
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
