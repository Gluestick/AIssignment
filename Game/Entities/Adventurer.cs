using System.Drawing;
using ISGPAI.Game.SteeringBehaviors;

namespace ISGPAI.Game.Entities
{
	internal class Adventurer : MovingEntity
	{
		private ISteeringBehavior _steering;

		public Adventurer()
		{
			_steering = new KeyboardSteering();
		}

		public override void Update(double elapsed)
		{
		}

		public override void Paint(Graphics g)
		{
			const int Size = 20;
			g.FillEllipse(Brushes.Black,
				(int)Position.X - Size / 2,
				(int)Position.Y - Size / 2,
				Size, Size
			);
		}
	}
}
