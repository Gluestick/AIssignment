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
				lastInConga = new Follower(world, lastInConga, 25);
				world.AddEntity(lastInConga);
			}
			world.AddCollidingEntity(new House(new Vector2(0, -180)));
			world.AddCollidingEntity(new Tree(new Vector2(-200, -200)));
			world.AddCollidingEntity(new Tree(new Vector2(200, -200)));
			world.AddEntity(new Explorer(world));
			return world;
		}
	}
}
