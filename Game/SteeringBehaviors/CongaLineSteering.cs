using System.Collections.Generic;
using ISGPAI.Game.Entities;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game.SteeringBehaviors
{
	internal class CongaLineSteering : ISteeringBehavior
	{
		private Stack<Entity> _congaLine;
		private Entity _leader;

		public CongaLineSteering(Entity leader)
		{
			this._congaLine = new Stack<Entity>();
			this._leader = leader;
		}

		public Vector2 Steer(MovingEntity agent, double elapsed)
		{
			throw new System.NotImplementedException();
		}
	}
}
