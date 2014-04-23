using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISGPAI.Game.Maths;
using ISGPAI.Game.SteeringBehaviors;

namespace ISGPAI.Game.Entities
{
	internal class Follower : MovingEntity
	{
		private ISteeringBehavior _steering;

		public Follower(Entity target)
		{
			_steering = new ArriveSteering(target);
		}

		public override void Update(double elapsed)
		{
			Vector2 steeringForce = _steering.Steer(this, elapsed) * 1000;
			Vector2 acceleration = steeringForce / Mass;
			Velocity += acceleration * elapsed;
			Velocity = Velocity.Truncate(MaxSpeed);
			Position += Velocity * elapsed;
		}

		public override void Paint(System.Drawing.Graphics g)
		{
			const int Size = 10;
			g.FillEllipse(Brushes.Red,
				(int)Position.X - Size / 2,
				(int)Position.Y - Size / 2,
				Size, Size
			);
		}
	}
}
