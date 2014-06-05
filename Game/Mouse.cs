using System.Collections.Generic;
using System.Windows.Forms;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game
{
	static public class Mouse
	{
		private static Dictionary<MouseButtons, bool> _buttonStates =
			new Dictionary<MouseButtons, bool>();

		/// <summary>
		/// Current position of the mouse in the game world.
		/// </summary>
		public static Vector2 Position { get; set; }

		/// <summary>
		/// Check if the specified mouse button is pressed.
		/// </summary>
		public static bool IsButtonDown(MouseButtons button)
		{
			if (_buttonStates.ContainsKey(button))
			{
				return _buttonStates[button];
			}
			return false;
		}

		/// <summary>
		/// Check if the specified mouse button is not pressed.
		/// </summary>
		public static bool IsButtonUp(MouseButtons button)
		{
			return !IsButtonDown(button);
		}

		public static void ChangeButtonState(MouseButtons button, bool down)
		{
			if (_buttonStates.ContainsKey(button))
			{
				_buttonStates[button] = down;
			}
			else
			{
				_buttonStates.Add(button, down);
			}
		}
	}
}
