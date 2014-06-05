using System;

namespace ISGPAI.Game.Maths
{
	/// <summary>
	/// Creates one Random instance to use throughout the entire program.
	/// </summary>
	public static class RandomHolder
	{
		private static Random _instance;

		public static Random Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new Random();
				}
				return _instance;
			}
		}
	}
}
