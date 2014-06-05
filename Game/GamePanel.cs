using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game
{
	/// <summary>
	/// Panel used to draw the game world in.
	/// </summary>
	public class GamePanel : Panel
	{
		private DateTime _timeSinceLastPaint;

		/// <summary>
		/// Game world that will be drawn on this panel.
		/// </summary>
		public World World { get; set; }

		public GamePanel()
		{
			_timeSinceLastPaint = DateTime.Now;
			DoubleBuffered = true;
			InitializeComponent();
		}

		/// <summary>
		/// Paint the game on this panel.
		/// </summary>
		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			BackColor = Color.FromArgb(56, 144, 88);
			int fps = (int)Math.Round(1 / (DateTime.Now - _timeSinceLastPaint).TotalSeconds, 0, MidpointRounding.AwayFromZero);
			_timeSinceLastPaint = DateTime.Now;
			e.Graphics.DrawString(
				string.Format("{0} FPS", fps),
				SystemFonts.DefaultFont,
				Brushes.Black,
				new PointF(10, 10)
			);
			e.Graphics.TranslateTransform(Width / 2, Height / 2);
			base.OnPaint(e);
			if (World != null)
			{
				World.Paint(e.Graphics);
			}
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// GamePanel
			// 
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GamePanel_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GamePanel_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GamePanel_MouseUp);
			this.ResumeLayout(false);

		}

		private void GamePanel_MouseMove(object sender, MouseEventArgs e)
		{
			Mouse.Position = new Vector2(e.X, e.Y);
		}

		private void GamePanel_MouseDown(object sender, MouseEventArgs e)
		{
			Mouse.ChangeButtonState(e.Button, true);
		}

		private void GamePanel_MouseUp(object sender, MouseEventArgs e)
		{
			Mouse.ChangeButtonState(e.Button, false);
		}
	}
}
