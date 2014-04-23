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
			Vector2 steeringForce;
			foreach (Entity entity in _world.Entities)
			{
				if (agent == entity)
				{
					// Can't escape from yourself, so continue with the next one.
					continue;
				}

			}
			throw new System.NotImplementedException();
		}
	}
}
