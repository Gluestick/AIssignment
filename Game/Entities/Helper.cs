using System;
using System.Drawing;
using System.Linq;
using ISGPAI.Game.Artwork;
using ISGPAI.Game.Maths;
using ISGPAI.Game.SteeringBehaviors;

namespace ISGPAI.Game.Entities
{
	public class Helper : MovingEntity
	{
		// In seconds.
		private double _timeSinceLastAnimation;
		private const double AnimationInterval = 0.05;

		// If this entity's speed is below this value, it will stand still
		// (instead of showing the walking animation.
		private const double AnimationSpeedThreshold = 25;

		// Time in seconds.
		private const double RestTime = 0.25;
		private const double FleeTime = 1.0;

		// Goals and their current scores
		private int _safety;
		private int _helping;
		private int _energy;
		private World _world;

		private Action _currentAction;
		private bool _awaitingTask;
		private double _remainingRest;
		private double _remainingFlee;
		private SeekSteering _seek;
		private FleeSteering _flee;
		private Creeper _target;
		private AnimatedSpriteSet _sprite;

		public Helper(World world)
		{
			MaxSpeed = 200;
			Mass = 1;

			_safety = 5;
			_helping = 5;
			_energy = 5;
			_world = world;
			_awaitingTask = true;
			_sprite = new AnimatedSpriteSet("helper.png", 32, 64);
		}

		public override void Update(double elapsed)
		{
			if (_awaitingTask)
			{
				_awaitingTask = false;
				double fleeScore = ScoreAfterFleeing();
				double attackScore = ScoreAfterAttacking();
				double restScore = ScoreAfterResting();

				if (fleeScore < attackScore && fleeScore < restScore)
				{
					_currentAction = Action.Flee;
					Flee();
				}
				else if (attackScore < fleeScore && attackScore < restScore)
				{
					_currentAction = Action.Attack;
					Attack();
				}
				else
				{
					_currentAction = Action.Rest;
					Rest();
				}
			}
			else
			{
				switch (_currentAction)
				{
				case Action.Flee:
						FleeUpdate(elapsed);
						break;
				case Action.Attack:
						AttackUpdate(elapsed);
						break;
				case Action.Rest:
						RestUpdate(elapsed);
						break;
				}
			}
			UpdateSpriteDirection();
			UpdateSpriteAnimation(elapsed);
		}

		private void RestUpdate(double elapsed)
		{
			_remainingRest -= elapsed;
			if (_remainingRest <= 0)
			{
				_awaitingTask = true;
			}
		}

		private void AttackUpdate(double elapsed)
		{
			if (_target == null)
			{
				_awaitingTask = true;
				return;
			}
			double distance = (Position - _target.Position).Length;
			if (distance < 25)
			{
				_target.Health -= 10;
				_awaitingTask = true;
			}
			else
			{
				Vector2 steeringForce = _seek.Steer(this, elapsed) * 8;
				Vector2 acceleration = steeringForce / Mass;
				Velocity += acceleration * elapsed;
				Velocity = Velocity.Truncate(MaxSpeed);
				Position += Velocity * elapsed;
			}
		}

		private void FleeUpdate(double elapsed)
		{
			_remainingFlee -= elapsed;
			if (_remainingFlee <= 0 || _target == null)
			{
				_awaitingTask = true;
			}
			else
			{
				Vector2 steeringForce = _flee.Steer(this, elapsed) * 8;
				Vector2 acceleration = steeringForce / Mass;
				Velocity += acceleration * elapsed;
				Velocity = Velocity.Truncate(MaxSpeed);
				Position += Velocity * elapsed;
			}
		}

		public override void Paint(Graphics g)
		{
			_sprite.PaintAt(g, this.Position);
		}

		private Creeper GetClosestEnemy()
		{
			return (Creeper)_world.Entities.Where(e => e is Creeper)
				.OrderBy(e => (e.Position - Position).Length)
				.FirstOrDefault();
		}

		// Score check methods
		private int ScoreAfterFleeing()
		{
			int score = (int)Math.Pow(10 - Math.Min(10, _safety + 4), 2);
			score += (int)Math.Pow(10 - Math.Max(0, _helping - 2), 2);
			score += (int)Math.Pow(10 - Math.Max(0, _energy - 1), 2);
			return score;
		}

		private int ScoreAfterAttacking()
		{
			int score = (int)Math.Pow(10 - Math.Max(0, _safety - 2), 2);
			score += (int)Math.Pow(10 - Math.Min(10, _helping + 3), 2);
			score += (int)Math.Pow(10 - Math.Max(0, _energy - 2), 2);
			return score;
		}

		private int ScoreAfterResting()
		{
			int score = (int)Math.Pow(10 - Math.Max(0, _safety - 1), 2);
			score += (int)Math.Pow(10 - Math.Max(0, _helping - 2), 2);
			score += (int)Math.Pow(10 - Math.Min(10, _energy + 3), 2);
			return score;
		}

		// Action methods
		private void Flee()
		{
			_safety = Math.Min(10, _safety + 4);
			_helping = Math.Max(0, _helping - 2);
			_energy = Math.Max(0, _energy - 1);
			_target = GetClosestEnemy();
			_flee = new FleeSteering(_target);
		}

		private void Attack()
		{
			_safety = Math.Max(0, _safety - 2);
			_helping = Math.Min(10, _helping + 2);
			_energy = Math.Max(0, _energy - 2);
			_target = GetClosestEnemy();
			_seek = new SeekSteering(_target);
			_remainingFlee = FleeTime;
		}

		private void Rest()
		{
			_helping = Math.Max(0, _helping - 2);
			_energy = Math.Min(10, _energy + 2);
			Velocity = new Vector2();
			_remainingRest = RestTime;
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

		private enum Action
		{
			Flee,
			Attack,
			Rest
		}
	}
}
