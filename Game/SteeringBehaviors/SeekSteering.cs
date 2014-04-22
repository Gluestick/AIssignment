﻿using ISGPAI.Game.Entities;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game.SteeringBehaviors
{
	/// <summary>
	/// Steering behavior that seeks a certain entity.
	/// </summary>
	internal class SeekSteering : ISteeringBehavior
	{
		private Entity _target;

		/// <summary>
		/// Construct a steering behavior that seeks the specified target.
		/// </summary>
		public SeekSteering(Entity target)
		{
			this._target = target;
		}

		/// <summary>
		/// Calculate steering velocity for the agent.
		/// </summary>
		public Vector2 Steer(MovingEntity agent, double elapsed)
		{
			Vector2 desiredVelocity = Vector2.Normalize(
				_target.Position - agent.Position
			) * agent.MaxSpeed;
			return desiredVelocity - agent.Velocity;
		}
	}
}
