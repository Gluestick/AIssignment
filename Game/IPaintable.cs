using System.Drawing;

namespace ISGPAI.Game
{
	/// <summary>
	/// Implementations will be able to paint on a GDI+ canvas.
	/// </summary>
	public interface IPaintable
	{
		void Paint(Graphics g);
	}
}
