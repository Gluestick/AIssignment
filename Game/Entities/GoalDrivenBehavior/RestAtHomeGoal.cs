using System.Linq;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game.Entities.GoalDrivenBehavior
{
	public class RestAtHomeGoal : CompositeGoal<Helper>
	{
		private static Vector2 DoorOffset = new Vector2(0, 60);
		private World _world;

		public RestAtHomeGoal(Helper owner, World world)
		{
			this._owner = owner;
			this._world = world;
		}

		public override void Activate()
		{
			_status = Status.Active;
			Entity home = _world.Entities.FirstOrDefault(e => e is House);
			if (home == null)
			{
				// Oops, you're homeless!
				_status = Status.Failed;
				return;
			}
			AddSubGoal(new LeaveHouseGoal(_owner));
			AddSubGoal(new RestGoal(_owner));
			AddSubGoal(new EnterHouseGoal(_owner));
			AddSubGoal(new SeekGoal(_owner, home.Position + DoorOffset));
		}

		public override Status Process()
		{
			ActivateIfInactive();
			if (_status == Status.Failed)
			{
				return _status;
			}
			_status = ProcessSubGoals();
			ReactivateIfFailed();
			return _status;
		}

		public override void Terminate()
		{
		}

		public override string Name
		{
			get { return "Rest at home"; }
		}
	}
}
