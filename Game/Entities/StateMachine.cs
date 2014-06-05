namespace ISGPAI.Game.Entities
{
	/// <summary>
	/// Generic statemachine.
	/// </summary>
	public class StateMachine<T> : IStateChangeable<T>
	{
		private T _owner;
		private State<T> _currentState;

		public StateMachine(T owner, State<T> startState)
		{
			this._owner = owner;
			this._currentState = startState;
		}

		/// <summary>
		/// Updates the statemachine and changes state if necessary.
		/// </summary>
		public void Update(double elapsed)
		{
			if (_currentState != null)
			{
				_currentState.Update(elapsed);
			}
		}

		public void ChangeState(State<T> newState)
		{
			if (_currentState != null)
			{
				_currentState.Exit();
			}
			_currentState = newState;
			_currentState.Enter();
		}
	}
}
