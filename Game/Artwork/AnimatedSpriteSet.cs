using System.Drawing;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game.Artwork
{
	public class AnimatedSpriteSet
	{
		private Image _spriteSet;
		private int _spriteWidth;
		private int _spriteHeight;
		private int _columns;

		private int _currentColumn;
		private int _currentRow;

		private Rectangle _srcRectangle;

		public AnimatedSpriteSet(string fileName,
			int spriteWidth, int spriteHeight)
		{
			this._spriteWidth = spriteWidth;
			this._spriteHeight = spriteHeight;

			_spriteSet = Image.FromFile(fileName);
			this._columns = _spriteSet.Width / _spriteWidth;
			AdvanceAnimation();
		}

		public void AdvanceAnimation()
		{
			_currentColumn = (_currentColumn + 1) % _columns;
		}

		public void ChangeRow(int row)
		{
			this._currentRow = row;
		}

		public void ChangeColumn(int column)
		{
			this._currentColumn = column;
		}

		public void PaintAt(Graphics g, Vector2 position)
		{
			_srcRectangle = new Rectangle(
				_currentColumn * _spriteWidth,
				_currentRow * _spriteHeight,
				_spriteWidth,
				_spriteHeight
			);
			Rectangle destRectangle = new Rectangle(
				(int)position.X - _spriteWidth / 2,
				(int)position.Y - _spriteHeight / 2,
				_spriteWidth, _spriteHeight);
			g.DrawImage(_spriteSet, destRectangle, _srcRectangle, GraphicsUnit.Pixel);
		}
	}
}
