using System.Windows.Forms;
using ISGPAI.Game.Entities;

namespace ISGPAI.Game.SteeringBehaviors
{
	/// <summary>
	/// Returns a force in the direction of the current arrow key state.
	/// </summary>
	internal class KeyboardSteering : ISteeringBehavior
	{
		private double _steeringForce;

		public KeyboardSteering(double steeringForce)
		{
			_steeringForce = steeringForce;
		}

		public Vector2 Steer(MovingEntity agent)
		{
			Vector2 force = new Vector2();
			if (Keyboard.IsKeyDown(Keys.Left))
			{
				force.X -= _steeringForce;
			}
			if (Keyboard.IsKeyDown(Keys.Right))
			{
				force.X += _steeringForce;
			}
			if (Keyboard.IsKeyDown(Keys.Down))
			{
				force.Y -= _steeringForce;
			}
			if (Keyboard.IsKeyDown(Keys.Up))
			{
				force.Y += _steeringForce;
			}
			return force;
		}
	}
}
