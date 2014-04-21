using ISGPAI.Game.Entities;

namespace ISGPAI.Game
{
	/// <summary>
	/// Create a test world with some entities.
	/// </summary>
	internal static class TestWorldFactory
	{
		public static World CreateWorld()
		{
			World world = new World();
			world.AddEntity(new Adventurer());
			world.AddEntity(new Creeper(world));
			return world;
		}
	}
}
