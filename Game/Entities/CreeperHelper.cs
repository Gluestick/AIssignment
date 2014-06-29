using System;
using System.Drawing;

namespace ISGPAI.Game.Entities
{
	public class CreeperHelper : MovingEntity
	{
		private int _safety;
		private int _helping;
		private int _energy;

		public CreeperHelper()
		{
			MaxSpeed = 100;
			Mass = 1;
		}

		public override void Update(double elapsed)
		{
			throw new NotImplementedException();
		}

		public override void Paint(Graphics g)
		{
			throw new NotImplementedException();
		}

		// Score check methods
		private int ScoreAfterFleeing()
		{
			int score = (int)Math.Pow(Math.Min(10, _safety + 4), 2);
			score += (int)Math.Pow(Math.Max(0, _helping - 2), 2);
			score += (int)Math.Pow(Math.Max(0, _energy - 1), 2);
			return score;
		}

		private int ScoreAfterAttacking()
		{
			int score = (int)Math.Pow(Math.Max(0, _safety - 2), 2);
			score += (int)Math.Pow(Math.Min(10, _helping + 2), 2);
			score += (int)Math.Pow(Math.Max(0, _energy - 2), 2);
			return score;
		}

		private int ScoreAfterResting()
		{
			int score = (int)Math.Pow(_safety, 2);
			score += (int)Math.Pow(Math.Max(0, _helping - 2), 2);
			score += (int)Math.Pow(Math.Min(10, _energy + 2), 2);
			return score;
		}

		// Action methods
		private void Flee()
		{
			_safety = Math.Min(10, _safety + 4);
			_helping = Math.Max(0, _helping - 2);
			_energy = Math.Max(0, _energy - 1);
			throw new NotImplementedException();
		}

		private void Attack()
		{
			_safety = Math.Max(0, _safety - 2);
			_helping = Math.Min(10, _helping + 2);
			_energy = Math.Max(0, _energy - 2);
			throw new NotImplementedException();
		}

		private void Rest()
		{
			_helping = Math.Min(0, _helping - 2);
			_energy = Math.Max(10, _energy + 2);
			throw new NotImplementedException();
		}
	}
}
