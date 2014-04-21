﻿using ISGPAI.Game.Entities;

namespace ISGPAI.Game.SteeringBehaviors
{
	/// <summary>
	/// Strategy for steering behavior.
	/// </summary>
	internal interface ISteeringBehavior
	{
		/// <summary>
		/// Calculates a force for the agent.
		/// </summary>
		Vector2 Steer(MovingEntity agent, double elapsed);
	}
}
