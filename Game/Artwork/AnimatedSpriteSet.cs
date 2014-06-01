using System.Drawing;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game.Artwork
{
	internal class AnimatedSpriteSet
	{
		private Image _spriteSet;
		private int _spriteWidth;
		private int _spriteHeight;
		private int _columns;

		private Rectangle _srcRectangle;

		public AnimatedSpriteSet(string fileName,
			int spriteWidth, int spriteHeight)
		{
			this._spriteWidth = spriteWidth;
			this._spriteHeight = spriteHeight;

			_spriteSet = Image.FromFile(fileName);
			this._columns = _spriteSet.Width / _spriteWidth;
		}

		public void PaintAt(Graphics g, Vector2 position)
		{
			_srcRectangle = new Rectangle(0 * _spriteWidth, 0 * _spriteHeight,
				1 * _spriteWidth, 1 * _spriteHeight);
			Rectangle destRectangle = new Rectangle((int)position.X, (int)position.Y,
				_spriteWidth, _spriteHeight);
			g.DrawImage(_spriteSet, destRectangle, _srcRectangle, GraphicsUnit.Pixel);
		}
	}
}
