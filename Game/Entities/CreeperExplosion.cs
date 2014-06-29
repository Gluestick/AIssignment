using System.Drawing;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game.Entities
{
	public class CreeperExplosion : Entity
	{
		private const double StartRadius = 10;
		private const double MaxRadius = 100;
		private const double Duration = 0.2;

		private Brush _brush = Brushes.Yellow;
		private World _world;
		private double _currentRadius;

		public CreeperExplosion(World world, Vector2 position)
		{
			Position = position;
			_world = world;
			_currentRadius = StartRadius;
		}
		public override void Update(double elapsed)
		{
			if (_currentRadius >= MaxRadius)
			{
				_world.RemoveEntity(this);
				return;
			}
			_currentRadius += (MaxRadius - StartRadius) * (elapsed / Duration);
		}

		public override void Paint(Graphics g)
		{
			g.FillEllipse(_brush,
				(int)(Position.X - _currentRadius),
				(int)(Position.Y - _currentRadius),
				(int)(_currentRadius * 2),
				(int)(_currentRadius * 2)
			);
		}
	}
}
