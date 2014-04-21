namespace ISGPAI.Game.Entities
{
	internal class StateMachine<T>
		where T : Entity
	{
		private Entity _owner;

		public StateMachine(Entity owner)
		{
			this._owner = owner;
		}
	}
}
