using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ISGPAI.Game.Artwork;
using ISGPAI.Game.Collections;
using ISGPAI.Game.Maths;
using ISGPAI.Game.SteeringBehaviors;

namespace ISGPAI.Game.Entities
{
	public class Adventurer : MovingEntity
	{
		// In seconds.
		private const double AnimationInterval = 0.05;

		// If this entity's speed is below this value, it will stand still
		// (instead of showing the walking animation.
		private const double AnimationSpeedThreshold = 25;

		private const double Drag = 2000;
		private const double NavigationDistance = 12;

		private World _world;
		private ISteeringBehavior _keyboardSteering;
		private SeekAtSteering _seekAtSteering;
		private AnimatedSpriteSet _spriteSet;
		private ShortestPath _path;
		private IEnumerator<GraphNode> _pathEnum;

		private Pen ConsideredEdgePen = new Pen(Brushes.Orange, 2);
		private Pen PathPen = new Pen(Brushes.Red, 2);

		// In seconds.
		private double _timeSinceLastAnimation;

		public Adventurer(World world)
		{
			this._keyboardSteering = new KeyboardSteering();
			this._seekAtSteering = new SeekAtSteering();
			this._spriteSet = new AnimatedSpriteSet("adventurer.png", 32, 64);
			this._world = world;
			Mass = 1;
			MaxSpeed = 400;
		}

		public override void Update(double elapsed)
		{
			if (Mouse.IsButtonDown(MouseButtons.Left))
			{
				if (_path == null)
				{
					CreatePath();
				}
			}

			// Navigate to the previously clicked location.
			if (_path != null)
			{
				FollowPath(elapsed);
			}
			else // Use keyboard steering to naviate the adventurer.
			{
				SteerWithKeyboard(elapsed);
			}

			UpdateSpriteDirection();
			UpdateSpriteAnimation(elapsed);
		}

		private void CreatePath()
		{
			// Calculate shortest path from current position to
			// the current mouse position and store the IEnumerator
			// of that path for future navigation.
			GraphNode nearestCurrent =
				_world.Graph.NearestNode(Position);
			GraphNode nearestDestination =
				_world.Graph.NearestNode(Mouse.Position);
			_path = new AStarAlgorithm(_world.Graph)
				.GetShortestPath(nearestCurrent, nearestDestination);
			_pathEnum = _path.Path.GetEnumerator();
			if (!_pathEnum.MoveNext())
			{
				// Delete path if we're already at the destination.
				_path = null;
			}
		}

		private void SteerWithKeyboard(double elapsed)
		{
			Vector2 steeringForce = _keyboardSteering.Steer(this, elapsed) * 10;
			Vector2 acceleration = steeringForce / Mass;
			Velocity += acceleration * elapsed;
			Velocity = Velocity.Truncate(MaxSpeed);
			Position += Velocity * elapsed;
			if (acceleration.Length == 0)
			{
				if (Velocity.Length - Drag * elapsed > 0)
				{
					Velocity = Velocity.Truncate(Velocity.Length - Drag * elapsed);
				}
				else
				{
					Velocity = new Vector2();
				}
			}
		}

		private void FollowPath(double elapsed)
		{
			// Move to the next node in our path if we are close enough to
			// our current target node.
			if ((Position - _pathEnum.Current.Position).Length < NavigationDistance)
			{
				// Set path to null if we have reached our destination.
				if (!_pathEnum.MoveNext())
				{
					_path = null;
				}
			}
			if (_path != null)
			{
				_seekAtSteering.Location = _pathEnum.Current.Position;
				Vector2 steeringForce = _seekAtSteering.Steer(this, elapsed) * 10;
				Vector2 acceleration = steeringForce / Mass;
				Velocity += acceleration * elapsed;
				Velocity = Velocity.Truncate(MaxSpeed);
				Position += Velocity * elapsed;
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
			if (_path != null)
			{
				var enumerator = _path.Path.GetEnumerator();
				foreach (GraphEdge edge in _path.ConsideredEdges)
				{
					g.DrawLine(ConsideredEdgePen,
						(int)edge.Source.Position.X, (int)edge.Source.Position.Y,
						(int)edge.Destination.Position.X, (int)edge.Destination.Position.Y
					);
				}
				enumerator.MoveNext();
				GraphNode last = enumerator.Current;
				while (enumerator.MoveNext())
				{
					g.DrawLine(PathPen,
						(int)last.Position.X, (int)last.Position.Y,
						(int)enumerator.Current.Position.X, (int)enumerator.Current.Position.Y
					);
					last = enumerator.Current;
				}
			}
			_spriteSet.PaintAt(g, this.Position);
		}
	}
}
