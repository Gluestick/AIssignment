using ISGPAI.Game.Entities;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game.SteeringBehaviors
{
	internal class ArriveInFrontOf : ISteeringBehavior
	{
		private MovingEntity _target;
		private double _distance;
		private ArriveAtSteering _arriveAtSteering;

		public ArriveInFrontOf(MovingEntity target, double distance)
		{
			this._target = target;
			this._distance = distance;
			this._arriveAtSteering = new ArriveAtSteering(target.Position);
		}

		public Vector2 Steer(MovingEntity agent, double elapsed)
		{
			_arriveAtSteering.Location = _target.Position - (_target.Heading * _distance);
			return _arriveAtSteering.Steer(agent, elapsed);
		}
	}
}
