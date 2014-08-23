using System.Collections.Generic;

namespace ISGPAI.Game.Entities.GoalDrivenBehavior
{
	public class HelperThinkGoal : CompositeGoal<Helper>
	{
		private World _world;
		private int _iterator = 0;

		public HelperThinkGoal(Helper owner, World world)
		{
			this._owner = owner;
			this._world = world;
		}

		public override void Activate()
		{
			_status = Status.Active;
			AddNewGoal();
		}

		public override Status Process()
		{
			ActivateIfInactive();
			if (_subGoals.Count == 0)
			{
				AddNewGoal();
			}
			ProcessSubGoals();
			return Status.Active;
		}

		public override void Terminate()
		{
		}

		private void AddNewGoal()
		{
			switch (_iterator % 3)
			{
				case 0:
					AddSubGoal(new AttackCreeperGoal(_owner, _world));
					break;
				case 1:
					AddSubGoal(new MotivateExplorerGoal(_owner, _world));
					break;
				case 2:
					AddSubGoal(new RestAtHomeGoal(_owner, _world));
					break;
			}
			_iterator++;
		}

		public override string Name
		{
			get { return "Think"; }
		}
	}
}
