namespace ISGPAI.Game.Entities
{
	/// <summary>
	/// State machine for entities.
	/// </summary>
	/// <typeparam name="T">An implementation of the Entity class.</typeparam>
	internal class StateMachine<T>
		where T : Entity
	{
		private Entity _owner;

		public StateMachine(Entity owner)
		{
			this._owner = owner;
		}

		/// <summary>
		/// Update the statemachine and change state if necessary.
		/// </summary>
		public void Update()
		{
			throw new System.NotImplementedException();
		}
	}
}
