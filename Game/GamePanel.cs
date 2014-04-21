using System.Drawing;
using System.Windows.Forms;

namespace ISGPAI.Game
{
	/// <summary>
	/// Panel used to draw the game world in.
	/// </summary>
	internal class GamePanel : Panel
	{
		/// <summary>
		/// Game world that will be drawn on this panel.
		/// </summary>
		public World World { get; set; }

		public GamePanel()
		{
			DoubleBuffered = true;
			BackColor = Color.White;
		}

		/// <summary>
		/// Paint the game on this panel.
		/// </summary>
		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.TranslateTransform(Width / 2, Height / 2);
			base.OnPaint(e);
			if (World != null)
			{
				World.Paint(e.Graphics);
			}
		}
	}
}
