using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ISGPAI.Game
{
	/// <summary>
	/// Static class with methods to inspect the keyboard's state.
	/// </summary>
	internal static class Keyboard
	{
		[DllImport("user32.dll")]
		private static extern short GetAsyncKeyState(Keys key);

		/// <summary>
		/// Checks if the specified key is currently being pressed.
		/// </summary>
		public static bool IsKeyDown(Keys key)
		{
			return GetAsyncKeyState(key) != 0;
		}
	}
}
