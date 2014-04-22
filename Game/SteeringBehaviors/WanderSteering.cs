using ISGPAI.Game.Entities;

namespace ISGPAI.Game.SteeringBehaviors
{
	/// <summary>
	/// Returns a force that makes an entity wander randomly around the world.
	/// </summary>
	internal class WanderSteering : ISteeringBehavior
	{
		private double _radius;
		private double _distance;
		private double _jitter;
		private Vector2 _wanderTarget;

		public Vector2 Steer(MovingEntity agent, double elapsed)
		{
			throw new System.NotImplementedException();
			double jitterThisTimeSlice = _jitter * elapsed;
			_wanderTarget += new Vector2(
				RandomDouble() * jitterThisTimeSlice,
				RandomDouble() * jitterThisTimeSlice
			);
			_wanderTarget = Vector2.Normalize(_wanderTarget);
			_wanderTarget *= _radius;
			Vector2 target = _wanderTarget + new Vector2(_distance, 0);
			Vector2 worldSpaceTarget = Transformation.PointToWorldSpace(
				target, agent.Heading, agent.Side, agent.Position);
			return worldSpaceTarget - agent.Position;
		}

		/// <summary>
		/// Returns a random value of n where -1 < n < 1
		/// </summary>
		/// <returns></returns>
		private double RandomDouble()
		{
			return RandomHolder.Instance.NextDouble() - RandomHolder.Instance.NextDouble();
		}
	}
}
