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
			world.AddEntity(new Follower(adventurer));
			return world;
		}
	}
}
