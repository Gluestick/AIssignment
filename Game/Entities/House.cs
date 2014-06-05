using System.Drawing;
using ISGPAI.Game.Artwork;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game.Entities
{
	internal class House : Entity
	{
		private AnimatedSpriteSet _spriteSet;

		public House(Vector2 position)
		{
			this.Position = position;
			_spriteSet = new AnimatedSpriteSet("house.png", 224, 144);
		}

		public override void Update(double elapsed)
		{
		}

		public override void Paint(Graphics g)
		{
			_spriteSet.PaintAt(g, Position);
		}
	}
}
