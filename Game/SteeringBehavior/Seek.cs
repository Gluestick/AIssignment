namespace ISGPAI.Game.SteeringBehavior
{
	/// <summary>
	/// Steering behavior that seeks a certain entity.
	/// </summary>
	internal class Seek : ISteeringBehavior
	{
		private Entity _target;

		/// <summary>
		/// Construct a steering behavior that seeks the specified target.
		/// </summary>
		public Seek(Entity target)
		{
			this._target = target;
		}

		public Vector2 Steer(MovingEntity agent)
		{
			throw new System.NotImplementedException();
		}
	}
}
