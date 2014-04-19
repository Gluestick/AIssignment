namespace ISGPAI.Game
{
	/// <summary>
	/// Abstract class for entities within the game world.
	/// </summary>
	abstract internal class Entity
	{
		/// <summary>
		/// Gets the Id that uniquely identifies this entity.
		/// </summary>
		public int Id
		{
			get
			{
				return _id;
			}
		}

		private int _id;
		private static int _nextValidId = 0;

		// The BaseGameEntity constructor in the book takes an id as a parameter.
		// This means that whoever is creating an entity object is responsible
		// for picking a correct id. I thought it was a better idea to keep this
		// responsibility at one central place, so this constructor takes care
		// of that without needing any parameters. This also means that this
		// class does not need a setter for its id.
		public Entity()
		{
			_id = _nextValidId;
			_nextValidId++;
		}

		public abstract void Update();
	}
}
