using System;

namespace ISGPAI.Game
{
	/// <summary>
	/// Creates one Random instance to use throughout the entire program.
	/// </summary>
	internal static class RandomHolder
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
