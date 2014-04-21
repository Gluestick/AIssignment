using System.Windows.Input;
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
			if (Keyboard.IsKeyDown(Key.Left))
			{
				force.X -= 1;
			}
			if (Keyboard.IsKeyDown(Key.Right))
			{
				force.X += 1;
			}
			if (Keyboard.IsKeyDown(Key.Down))
			{
				force.Y -= 1;
			}
			if (Keyboard.IsKeyDown(Key.Up))
			{
				force.Y += 1;
			}
			return force;
		}
	}
}
