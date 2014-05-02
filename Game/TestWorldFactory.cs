using ISGPAI.Game.Entities;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game
{
	/// <summary>
	/// Create a test world with some entities.
	/// </summary>
	internal static class TestWorldFactory
	{
		public static World CreateWorld()
		{
			Adventurer adventurer = new Adventurer();
			World world = new World();
			world.AddEntity(adventurer);

			// Conga conga conga conga!
			const int CongaSize = 4;
			MovingEntity lastInConga = adventurer;
			for (int i = 0; i < CongaSize; i++)
			{
				lastInConga = new Follower(lastInConga, 15);
				world.AddEntity(lastInConga);
			}
			return world;
		}
	}
}
