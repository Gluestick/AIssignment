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
			world.AddEntity(
				new Creeper(world)
				{
					Position = new Vector2(300, -200)
				}
			);


			// Conga conga conga conga!
			const int CongaSize = 5;
			MovingEntity lastInConga = adventurer;
			for (int i = 0; i < CongaSize; i++)
			{
				lastInConga = new Follower(lastInConga, 50);
				world.AddEntity(lastInConga);
			}
			return world;
		}
	}
}
