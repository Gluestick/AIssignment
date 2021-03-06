﻿using System.Drawing;
using ISGPAI.Game.Artwork;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game.Entities
{
	public class House : Entity
	{
		private AnimatedSpriteSet _spriteSet;

		public House(Vector2 position)
		{
			this.Position = position;
			this._size = new Vector2(224, 144);
			this._drawOrder = -1;
			_spriteSet = new AnimatedSpriteSet("house.png", (int)_size.X, (int)_size.Y);
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
