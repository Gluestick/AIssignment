using ISGPAI.Game.Entities;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game.SteeringBehaviors
{
	/// <summary>
	/// Steering behavior that seeks a certain entity.
	/// </summary>
	public class SeekSteering : ISteeringBehavior
	{
		private Entity _target;
		private SeekAtSteering _seekAtSteering;

		/// <summary>
		/// Construct a steering behavior that seeks the specified target.
		/// </summary>
		public SeekSteering(Entity target)
		{
			this._target = target;
			this._seekAtSteering = new SeekAtSteering();
		}

		/// <summary>
		/// Calculate steering velocity for the agent.
		/// </summary>
		public Vector2 Steer(MovingEntity agent, double elapsed)
		{
			_seekAtSteering.Location = _target.Position;
			return _seekAtSteering.Steer(agent, elapsed);
		}
	}
}
