namespace ISGPAI.Game.Entities
{
	/// <summary>
	/// Generic statemachine.
	/// </summary>
	internal class StateMachine<T>
	{
		private T _owner;
		private State<T> _currentState;

		public StateMachine(T owner, State<T> startState)
		{
			this._owner = owner;
			this._currentState = startState;
		}

		/// <summary>
		/// Update the statemachine and change state if necessary.
		/// </summary>
		public void Update(double elapsed)
		{
			throw new System.NotImplementedException();
		}
	}
}
