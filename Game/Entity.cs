namespace ISGPAI.Game
{
	/// <summary>
	/// Abstract class for entities within the game world.
	/// </summary>
	abstract internal class Entity
	{
		private int _id;
		private static int _nextValidId = 0;

		protected Vector2 _position;

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

		/// <summary>
		/// Get the current position of this entity in the game world.
		/// </summary>
		public Vector2 Position
		{
			get { return _position; }
			set { _position = value; }
		}

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
