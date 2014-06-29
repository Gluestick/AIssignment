using ISGPAI.Game.Entities;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game
{
	/// <summary>
	/// Create a test world with some entities.
	/// </summary>
	public static class TestWorldFactory
	{
		public static World CreateWorld()
		{
			World world = new World();
			Adventurer adventurer = new Adventurer(world);
			world.AddEntity(adventurer);
			world.AddEntity(new Creeper(world));

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
