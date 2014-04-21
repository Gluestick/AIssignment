using System;
using System.Threading;
using System.Windows.Forms;

namespace ISGPAI.Game
{
	public partial class GameForm : Form
	{
		private World _world;
		private Thread _gameThread;
		private long _timeSinceLastUpdate;
		private bool _playing;

		public GameForm()
		{
			InitializeComponent();
			InitializeGame();
		}

		/// <summary>
		/// Setup the gameloop and start it.
		/// </summary>
		private void InitializeGame()
		{
			_world = TestWorldFactory.CreateWorld();
			_gamePanel.World = _world;

			_gameThread = new Thread(GameLoop);
			_playing = true;
			_timeSinceLastUpdate = DateTime.Now.Ticks;
			_gameThread.Start();
		}

		/// <summary>
		/// The game loop. Updates and invalidates the game. Painting happens
		/// in the OnPaint method of GamePanel.
		/// </summary>
		private void GameLoop()
		{
			while (_playing)
			{
				long elapsedTicks = DateTime.Now.Ticks - _timeSinceLastUpdate;
				_timeSinceLastUpdate = DateTime.Now.Ticks;
				_world.Update((double)elapsedTicks / TimeSpan.TicksPerSecond);
				_gamePanel.Invalidate();
			}
		}

		/// <summary>
		/// Stops the gameloop, so the program will close.
		/// </summary>
		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);
			_playing = false;
		}
	}
}
