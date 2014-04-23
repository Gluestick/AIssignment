using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISGPAI.Game.Entities
{
	internal class Follower : MovingEntity
	{
		public override void Update(double elapsed)
		{
			throw new NotImplementedException();
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
