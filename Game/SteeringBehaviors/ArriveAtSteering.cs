using System;
using ISGPAI.Game.Entities;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game.SteeringBehaviors
{
	/// <summary>
	/// Steering behavior that steers towards a target, but slows down when close.
	/// </summary>
	internal class ArriveAtSteering : ISteeringBehavior
	{
		public Vector2 Location { get; set; }
		public float Distance { get; set; }

		public ArriveAtSteering(Vector2 location, float distance = 0)
		{
			this.Location = location;
			this.Distance = distance;
		}

		public Vector2 Steer(MovingEntity agent, double elapsed)
		{
			const double Deceleration = 1;

			Vector2 toTarget = Location - agent.Position;
			Vector2 toTargetDistance = Vector2.Normalize(toTarget);
			toTargetDistance *= toTarget.Length - Distance;
			double distance = toTargetDistance.Length;
			if (distance > 0)
			{
				double speed = distance / Deceleration;
				speed = Math.Min(speed, agent.MaxSpeed);
				Vector2 desiredVelocity = toTargetDistance * speed / distance;
				return desiredVelocity - agent.Velocity;
			}
			else
			{
				// We're ON our target... Don't move.
				return new Vector2(0, 0);
			}
		}
	}
}
