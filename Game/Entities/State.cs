namespace ISGPAI.Game.Entities
{
	internal abstract class State<T>
		where T : Entity
	{
		public abstract void Enter(T entity);
		public abstract void Update(T entity, double elapsed);
		public abstract void Exit(T entity);
	}
}
