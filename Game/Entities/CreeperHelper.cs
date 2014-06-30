using System;
using System.Diagnostics;
using System.Drawing;

namespace ISGPAI.Game.Entities
{
	public class CreeperHelper : MovingEntity
	{
		// Goals and their current scores
		private int _safety;
		private int _helping;
		private int _energy;

		private Action _currentAction;

		public CreeperHelper()
		{
			MaxSpeed = 100;
			Mass = 1;

			_safety = 5;
			_helping = 5;
			_energy = 5;
		}

		public override void Update(double elapsed)
		{
			double fleeScore = ScoreAfterFleeing();
			double attackScore = ScoreAfterAttacking();
			double restScore = ScoreAfterResting();

			if (fleeScore < attackScore && fleeScore < restScore)
			{
				_currentAction = Action.Flee;
				Flee();
			}
			else if (attackScore < fleeScore && attackScore < restScore)
			{
				_currentAction = Action.Attack;
				Attack();
			}
			else
			{
				_currentAction = Action.Rest;
				Rest();
			}
		}

		public override void Paint(Graphics g)
		{
			Debug.WriteLine(_currentAction);
		}

		// Score check methods
		private int ScoreAfterFleeing()
		{
			int score = (int)Math.Pow(10 - Math.Min(10, _safety + 4), 2);
			score += (int)Math.Pow(10 - Math.Max(0, _helping - 2), 2);
			score += (int)Math.Pow(10 - Math.Max(0, _energy - 1), 2);
			return score;
		}

		private int ScoreAfterAttacking()
		{
			int score = (int)Math.Pow(10 - Math.Max(0, _safety - 2), 2);
			score += (int)Math.Pow(10 - Math.Min(10, _helping + 3), 2);
			score += (int)Math.Pow(10 - Math.Max(0, _energy - 2), 2);
			return score;
		}

		private int ScoreAfterResting()
		{
			int score = (int)Math.Pow(10 - Math.Max(0, _safety - 1), 2);
			score += (int)Math.Pow(10 - Math.Max(0, _helping - 2), 2);
			score += (int)Math.Pow(10 - Math.Min(10, _energy + 3), 2);
			return score;
		}

		// Action methods
		private void Flee()
		{
			_safety = Math.Min(10, _safety + 4);
			_helping = Math.Max(0, _helping - 2);
			_energy = Math.Max(0, _energy - 1);
		}

		private void Attack()
		{
			_safety = Math.Max(0, _safety - 2);
			_helping = Math.Min(10, _helping + 2);
			_energy = Math.Max(0, _energy - 2);
		}

		private void Rest()
		{
			_helping = Math.Max(0, _helping - 2);
			_energy = Math.Min(10, _energy + 2);
		}

		private enum Action
		{
			Flee,
			Attack,
			Rest
		}
	}
}
