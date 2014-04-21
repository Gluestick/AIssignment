namespace ISGPAI.Game.Entities
{
	/// <summary>
	/// Implementations will have a ChangeState method.
	/// </summary>
	internal interface IStateChangeable<T>
	{
		void ChangeState(State<T> newState);
	}
}
