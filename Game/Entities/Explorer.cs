using System;
using System.Collections.Generic;
using System.Drawing;
using ISGPAI.Game.Artwork;
using ISGPAI.Game.Collections;
using ISGPAI.Game.Maths;
using ISGPAI.Game.SteeringBehaviors;

namespace ISGPAI.Game.Entities
{
	/// <summary>
	/// Moving entity that explorers the world graph. When the explorer is
	/// done exploring, it will start over, beginning at his current position.
	/// </summary>
	public class Explorer : MovingEntity
	{
		// In seconds.
		private double _timeSinceLastAnimation;
		private const double AnimationInterval = 0.05;

		// If this entity's speed is below this value, it will stand still
		// (instead of showing the walking animation.
		private const double AnimationSpeedThreshold = 25;

		/// <summary>
		/// When the explorer comes this close to its target node, it will
		/// advance to the next node.
		/// </summary>
		private const double TargetDistance = 10;

		private double _speedBoost;
		private const double BoostDecrement = 0.05;
		private Graph _graph;
		private IEnumerator<GraphNode> _enumerator;
		private GraphNode _current;
		private SeekAtSteering _steering;
		private AnimatedSpriteSet _sprite;

		public Explorer(World world)
		{
			this.Mass = 1;
			this.MaxSpeed = 100;
			this._speedBoost = 1;
			this._graph = world.Graph;
			this._steering = new SeekAtSteering();
			this._sprite = new AnimatedSpriteSet("explorer.png", 32, 64);
			Initialize();
		}

		public void SpeedBoost()
		{
			_speedBoost = 1.4;
		}

		private void Initialize()
		{
			GraphNode nearestNode = _graph.NearestNode(this.Position);
			_enumerator = _graph.GetDepthFirstEnumerable(nearestNode).GetEnumerator();
			_current = _enumerator.Current;
		}

		public override void Update(double elapsed)
		{
			_speedBoost -= BoostDecrement;
			_speedBoost = _speedBoost < 1 ? 1 : _speedBoost;
			double distance = (Position - _current.Position).Length;
			if (distance < TargetDistance)
			{
				if (_enumerator.MoveNext())
				{
					_current = _enumerator.Current;
					// Recursion stops when we have a target that's far enough
					// to move towards.
					Update(elapsed);
				}
			}
			else
			{
				_steering.Location = _current.Position;
				Vector2 steeringForce = _steering.Steer(this, elapsed) * 3 * _speedBoost;
				Vector2 acceleration = steeringForce / Mass;
				Velocity += acceleration * elapsed;
				Velocity = Velocity.Truncate(MaxSpeed * _speedBoost);
				Position += Velocity * elapsed;
			}
			UpdateSpriteDirection();
			UpdateSpriteAnimation(elapsed);
		}

		public override void Paint(Graphics g)
		{
			_sprite.PaintAt(g, this.Position);
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
