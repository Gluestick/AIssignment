using System.Drawing;

namespace ISGPAI.Game.Entities
{
	internal class Adventurer : MovingEntity
	{
		public override void Update()
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
