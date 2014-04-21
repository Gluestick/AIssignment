namespace ISGPAI.Game.Entities
{
	/// <summary>
	/// Generic statemachine.
	/// </summary>
	internal class StateMachine<T>
	{
		private T _owner;

		public StateMachine(T owner)
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
