namespace ISGPAI.Game.Entities
{
	/// <summary>
	/// Implementations will have a ChangeState method.
	/// </summary>
	public interface IStateChangeable<T>
	{
		void ChangeState(State<T> newState);
	}
}
