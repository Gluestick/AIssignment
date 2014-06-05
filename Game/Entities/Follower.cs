using System;
using System.Drawing;
using ISGPAI.Game.Maths;
using ISGPAI.Game.SteeringBehaviors;

namespace ISGPAI.Game.Entities
{
	/// <summary>
	/// Entity that arrives the specified target.
	/// </summary>
	internal class Follower : MovingEntity
	{
		private ArriveAtSteering _arrive;
		private SeparationSteering _separate;
		private MovingEntity _target;
		private double _rotation;
		private double _rotationSpeed;

		public Follower(World world, MovingEntity target, float distance)
		{
			MaxSpeed = 250;
			Mass = 1;
			this._separate = new SeparationSteering(world, distance);
			this._target = target;
			this._arrive = new ArriveAtSteering(target.Position, distance);
			_rotationSpeed = 10;
		}

		public override void Update(double elapsed)
		{
			_arrive.Location = _target.Position;
			Vector2 steeringForce = _arrive.Steer(this, elapsed);
			steeringForce += _separate.Steer(this, elapsed) * 2;
			steeringForce *= 6;
			Vector2 acceleration = steeringForce / Mass;
			Velocity += acceleration * elapsed;
			Velocity = Velocity.Truncate(MaxSpeed);
			Position += Velocity * elapsed;
			_rotation += _rotationSpeed * elapsed;
		}

		public override void Paint(System.Drawing.Graphics g)
		{
			const int Size = 3;
			const double Radius = 5;
			const int Count = 3;
			for (int i = 0; i < Count; i++)
			{
				double rotation = _rotation + 2 * Math.PI / Count * i;
				int xRotation = (int)(Math.Cos(rotation) * Radius);
				int yRotation = (int)(Math.Sin(rotation) * Radius);
				g.FillEllipse(Brushes.AntiqueWhite,
					(int)Position.X - Size / 2 + xRotation,
					(int)Position.Y - Size / 2 + yRotation,
					Size, Size
				);
			}
		}
	}
}
