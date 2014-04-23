using ISGPAI.Game.Entities;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game.SteeringBehaviors
{
	/// <summary>
	/// Makes the agent move away from any nearby entities.
	/// </summary>
	internal class SeperationSteering : ISteeringBehavior
	{
		private World _world;

		public SeperationSteering(World world)
		{
			this._world = world;
		}

		public Vector2 Steer(MovingEntity agent, double elapsed)
		{
			throw new System.NotImplementedException();
		}
	}
}
