﻿using ISGPAI.Game.Entities;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game.SteeringBehaviors
{
	/// <summary>
	/// Strategy for steering behavior.
	/// </summary>
	public interface ISteeringBehavior
	{
		/// <summary>
		/// Calculates a force for the agent.
		/// </summary>
		Vector2 Steer(MovingEntity agent, double elapsed);
	}
}
