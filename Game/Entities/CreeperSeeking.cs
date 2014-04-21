namespace ISGPAI.Game.Entities
{
	/// <summary>
	/// Creeper state when the creeper is nearby the adventurer.
	/// </summary>
	internal class CreeperSeeking : State<Creeper>
	{
		private Entity _target;

		public CreeperSeeking(Creeper agent, Entity target)
		{
			this._target = target;
		}

		public override void Enter(Creeper entity)
		{
			throw new System.NotImplementedException();
		}

		public override void Update(Creeper entity, double elapsed)
		{
			throw new System.NotImplementedException();
		}

		public override void Exit(Creeper entity)
		{
			throw new System.NotImplementedException();
		}
	}
}
