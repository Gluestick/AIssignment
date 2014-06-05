using System.Drawing;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game.Entities
{
	/// <summary>
	/// Abstract class for entities within the game world.
	/// </summary>
	public abstract class Entity : IPaintable
	{
		private int _id;
		private static int _nextValidId = 0;

		protected Vector2 _position;
		protected Vector2 _size;
		protected int _drawOrder;

		/// <summary>
		/// Gets the Id that uniquely identifies this entity.
		/// </summary>
		public int Id
		{
			get { return _id; }
		}

		/// <summary>
		/// Get the current position of this entity in the game world.
		/// </summary>
		public Vector2 Position
		{
			get { return _position; }
			set { _position = value; }
		}

		public Vector2 Size
		{
			get { return _size; }
			set { _size = value; }
		}

		/// <summary>
		/// The order at which entities are drawn. Entities with a high
		/// draw order are drawn before other entities.
		/// </summary>
		public int DrawOrder { get { return _drawOrder; } }

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

		/// <summary>
		/// Check if the given coordinate is inside this entity.
		/// </summary>
		public bool IsInside(Vector2 position)
		{
			return (position.X > Position.X &&
				position.X < Position.X + Size.X) &&
				(position.Y > Position.Y &&
				position.Y < Position.Y + Size.Y);
		}

		public abstract void Update(double elapsed);
		public abstract void Paint(Graphics g); // From IPaintable.
	}
}
