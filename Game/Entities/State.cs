namespace ISGPAI.Game.Entities
{
	/// <summary>
	/// Abstract class that provides methods for entity states.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	internal abstract class State<T>
		where T : Entity
	{
		public abstract void Enter(T entity);
		public abstract void Update(T entity, double elapsed);
		public abstract void Exit(T entity);
	}
}
