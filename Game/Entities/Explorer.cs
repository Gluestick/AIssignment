using System.Collections.Generic;
using System.Drawing;
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
		/// <summary>
		/// When the explorer comes this close to its target node, it will
		/// advance to the next node.
		/// </summary>
		private const double TargetDistance = 10;

		private Graph _graph;
		private IEnumerator<GraphNode> _enumerator;
		private GraphNode _current;
		private SeekAtSteering _steering;

		public Explorer(World world)
		{
			this.Mass = 1;
			this.MaxSpeed = 100;
			this._graph = world.Graph;
			this._steering = new SeekAtSteering();
			Initialize();
		}

		private void Initialize()
		{
			GraphNode nearestNode = _graph.NearestNode(this.Position);
			_enumerator = _graph.GetDepthFirstEnumerable(nearestNode).GetEnumerator();
			_current = _enumerator.Current;
		}

		public override void Update(double elapsed)
		{
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
				Vector2 steeringForce = _steering.Steer(this, elapsed) * 3;
				Vector2 acceleration = steeringForce / Mass;
				Velocity += acceleration * elapsed;
				Velocity = Velocity.Truncate(MaxSpeed);
				Position += Velocity * elapsed;
			}
		}

		public override void Paint(Graphics g)
		{
			const int Size = 15;
			g.FillEllipse(Brushes.Goldenrod,
				(int)Position.X - Size / 2,
				(int)Position.Y - Size / 2,
				Size, Size
			);
		}
	}
}
