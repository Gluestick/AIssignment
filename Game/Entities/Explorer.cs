using System;
using System.Collections.Generic;
using System.Drawing;
using ISGPAI.Game.Collections;
using ISGPAI.Game.SteeringBehaviors;

namespace ISGPAI.Game.Entities
{
	/// <summary>
	/// Moving entity that explorers the world graph. When the explorer is
	/// done exploring, it will start over, beginning at his current position.
	/// </summary>
	internal class Explorer : MovingEntity
	{
		private Graph _graph;
		private IEnumerator<GraphNode> _enumerator;
		private GraphNode _current;
		private SeekAtSteering _steering;

		public Explorer(World world)
		{
			this._graph = world.Graph;
			this._steering = new SeekAtSteering();
		}

		public override void Update(double elapsed)
		{
			throw new NotImplementedException();
		}

		public override void Paint(Graphics g)
		{
			throw new NotImplementedException();
		}
	}
}
