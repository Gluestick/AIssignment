using System.Drawing;

namespace ISGPAI.Game
{
	/// <summary>
	/// Implementations will be able to paint on a GDI+ canvas.
	/// </summary>
	internal interface IPaintable
	{
		void Paint(Graphics g);
	}
}
