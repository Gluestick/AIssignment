using System.Drawing;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game.Artwork
{
	internal class AnimatedBitmap
	{
		private int _spriteWidth;
		private int _spriteHeight;

		public AnimatedBitmap(string fileName,
			int spriteWidth, int spriteHeight)
		{
			this._spriteWidth = spriteWidth;
			this._spriteHeight = spriteHeight;
		}

		public void PaintAt(Graphics g, Vector2 position)
		{
		}
	}
}
