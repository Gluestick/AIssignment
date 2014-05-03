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

		/// <summary>
		/// The minimal distance required between the agent and any other entity
		/// for seperation to kick in.
		/// </summary>
		public double Radius { get; set; }

		public SeperationSteering(World world, double radius)
		{
			this._world = world;
			this.Radius = radius;
		}

		public Vector2 Steer(MovingEntity agent, double elapsed)
		{
			Vector2 steeringForce = new Vector2(0, 0);
			foreach (Entity entity in _world.Entities)
			{
				if (agent == entity)
				{
					// Can't escape from yourself, so continue with the next one.
					continue;
				}
				Vector2 distance = entity.Position - agent.Position;

				// Add seperating force to steering force for the current entity.
				if (distance.Length > Radius)
				{
					distance = Vector2.Normalize(distance) / distance.Length;
					steeringForce += distance;
				}
			}
			return steeringForce;
		}
	}
}
