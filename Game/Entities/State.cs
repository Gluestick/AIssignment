namespace ISGPAI.Game.Entities
{
	/// <summary>
	/// Abstract class that provides methods for entity states.
	/// </summary>
	internal abstract class State<T>
	{
		protected T _agent;

		public abstract void Enter();
		public abstract void Update(double elapsed);
		public abstract void Exit();

		protected State(T agent)
		{
			this._agent = agent;
		}
	}
}
