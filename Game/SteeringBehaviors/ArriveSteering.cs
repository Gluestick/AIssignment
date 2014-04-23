using ISGPAI.Game.Entities;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game.SteeringBehaviors
{
	internal class ArriveSteering : ISteeringBehavior
	{
		private Entity _target;

		public ArriveSteering(Entity target)
		{
			this._target = target;
		}

		public Vector2 Steer(MovingEntity agent, double elapsed)
		{
			throw new System.NotImplementedException();
		}
	}
}
