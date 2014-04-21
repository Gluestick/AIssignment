using System.Windows.Forms;
using ISGPAI.Game.Entities;

namespace ISGPAI.Game.SteeringBehaviors
{
	/// <summary>
	/// Returns a force in the direction of the current arrow key state.
	/// </summary>
	internal class KeyboardSteering : ISteeringBehavior
	{
		public Vector2 Steer(MovingEntity agent)
		{
			Vector2 force = new Vector2();
			if (Keyboard.IsKeyDown(Keys.Left))
			{
				force.X -= 1;
			}
			if (Keyboard.IsKeyDown(Keys.Right))
			{
				force.X += 1;
			}
			if (Keyboard.IsKeyDown(Keys.Down))
			{
				force.Y -= 1;
			}
			if (Keyboard.IsKeyDown(Keys.Up))
			{
				force.Y += 1;
			}
			return force;
		}
	}
}
