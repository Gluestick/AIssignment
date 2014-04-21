namespace ISGPAI.Game.Entities
{
	/// <summary>
	/// Creeper state when there is no adventurer nearby.
	/// </summary>
	internal class CreeperWandering : State<Creeper>
	{
		private World _world;

		public CreeperWandering(Creeper agent, World world)
			: base(agent)
		{
			this._world = world;
		}

		public override void Enter()
		{
			throw new System.NotImplementedException();
		}

		public override void Update(double elapsed)
		{
			throw new System.NotImplementedException();
		}

		public override void Exit()
		{
			throw new System.NotImplementedException();
		}
	}
}
