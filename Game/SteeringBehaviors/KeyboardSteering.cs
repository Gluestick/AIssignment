using System.Windows.Forms;
using ISGPAI.Game.Entities;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game.SteeringBehaviors
{
	/// <summary>
	/// Returns a force in the direction of the current arrow key state.
	/// </summary>
	internal class KeyboardSteering : ISteeringBehavior
	{
		public KeyboardSteering()
		{
		}

		public Vector2 Steer(MovingEntity agent, double elapsed)
		{
			Vector2 force = new Vector2();
			if (Keyboard.IsKeyDown(Keys.Left) || Keyboard.IsKeyDown(Keys.A))
			{
				force.X -= 1;
			}
			if (Keyboard.IsKeyDown(Keys.Right) || Keyboard.IsKeyDown(Keys.D))
			{
				force.X += 1;
			}
			if (Keyboard.IsKeyDown(Keys.Up) || Keyboard.IsKeyDown(Keys.W))
			{
				force.Y -= 1;
			}
			if (Keyboard.IsKeyDown(Keys.Down) || Keyboard.IsKeyDown(Keys.S))
			{
				force.Y += 1;
			}
			return force;
		}
	}
}
