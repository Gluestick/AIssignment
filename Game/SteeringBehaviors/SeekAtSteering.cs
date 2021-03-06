﻿using ISGPAI.Game.Entities;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game.SteeringBehaviors
{
	public class SeekAtSteering : ISteeringBehavior
	{
		public Vector2 Location { get; set; }

		public SeekAtSteering(Vector2 location)
		{
			this.Location = location;
		}

		public SeekAtSteering()
			: this(new Vector2())
		{
		}

		public Vector2 Steer(MovingEntity agent, double elapsed)
		{
			Vector2 desiredVelocity = Vector2.Normalize(
				this.Location - agent.Position
			) * agent.MaxSpeed;
			return desiredVelocity - agent.Velocity;
		}
	}
}
