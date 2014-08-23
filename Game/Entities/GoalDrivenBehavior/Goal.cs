using System.Drawing;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game.Entities.GoalDrivenBehavior
{
	public abstract class Goal<T>
		where T : Entity
	{
		protected T _owner;
		protected Status _status = Status.Inactive;

		public abstract void Activate();
		public abstract Status Process();
		public abstract void Terminate();
		public abstract void AddSubGoal(Goal<T> goal);

		private static readonly Font Font = new Font(FontFamily.GenericSansSerif, 8);

		public abstract string Name { get; }

		public bool IsActive()
		{
			return _status == Status.Active;
		}

		public bool IsInactive()
		{
			return _status == Status.Inactive;
		}

		public bool IsCompleted()
		{
			return _status == Status.Completed;
		}

		public bool HasFailed()
		{
			return _status == Status.Failed;
		}

		public virtual void DrawDebugText(Graphics g, float x, float y)
		{
			Brush brush = _status == Status.Active ? Brushes.White : Brushes.DarkGray;
			g.DrawString(Name, Font, brush, x, y);
		}
	}
}