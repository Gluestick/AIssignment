﻿using System;
using System.Windows.Forms;

namespace ISGPAI.Game
{
	public partial class GameForm : Form
	{
		const int FrameRate = 60;

		World _world;
		Timer _loopTimer;

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
			_world = new World();
			_loopTimer = new Timer();
			_loopTimer.Interval = 1000 / 60;
			_loopTimer.Tick += GameTick;
			_loopTimer.Start();
		}

		/// <summary>
		/// The game loop. Updates and invalidates the game. Painting happens
		/// in the OnPaint method.
		/// </summary>
		private void GameTick(object sender, EventArgs e)
		{
			_world.Update();
			Invalidate();
		}

		/// <summary>
		/// Paint the game.
		/// </summary>
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
		}
	}
}
