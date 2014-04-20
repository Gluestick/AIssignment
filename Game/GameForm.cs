using System;
using System.Threading;
using System.Windows.Forms;

namespace ISGPAI.Game
{
	public partial class GameForm : Form
	{
		World _world;
		Thread _gameThread;
		long _timeSinceLastUpdate;
		bool _playing;

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
			_timeSinceLastUpdate = 0;

			_gameThread = new Thread(GameLoop);
			_playing = true;
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
				_world.Update(_timeSinceLastUpdate);
				_timeSinceLastUpdate = DateTime.Now.Ticks;
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
