using System.Drawing;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game.Artwork
{
	internal class AnimatedSpriteSet
	{
		private Image _spriteSet;
		private int _spriteWidth;
		private int _spriteHeight;

		public AnimatedSpriteSet(string fileName,
			int spriteWidth, int spriteHeight)
		{
			this._spriteWidth = spriteWidth;
			this._spriteHeight = spriteHeight;

			_spriteSet = Image.FromFile(fileName);
		}

		public void PaintAt(Graphics g, Vector2 position)
		{
			g.DrawImage(_spriteSet, (int)position.X, (int)position.Y);
		}
	}
}
