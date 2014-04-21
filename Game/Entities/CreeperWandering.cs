namespace ISGPAI.Game.Entities
{
	/// <summary>
	/// Creeper state when there is no adventurer nearby.
	/// </summary>
	internal class CreeperWandering : State<Creeper>
	{
		public CreeperWandering(Creeper agent)
			: base(agent)
		{
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
