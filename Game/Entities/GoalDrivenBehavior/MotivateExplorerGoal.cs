using System;

namespace ISGPAI.Game.Entities.GoalDrivenBehavior
{
	public class MotivateExplorerGoal : CompositeGoal<Helper>
	{
		private World _world;
		private Explorer _target;

		public MotivateExplorerGoal(Helper owner, World world)
		{
			this._owner = owner;
			this._world = world;
		}

		public override void Activate()
		{
			_status = Status.Active;
			FindTarget();
			if (_target == null)
			{
				// There is no Explorer to motivate.
				_status = Status.Failed;
				return;
			}
			AddSubGoal(new MotivateGoal(_owner, _world));
			AddSubGoal(new SeekGoal(_owner, _target));
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

		private void FindTarget()
		{
			double shortestDistance = double.MaxValue;
			double currentDistance;
			Explorer closestExplorer;
			foreach (Entity entity in _world.Entities)
			{
				currentDistance = (entity.Position - _owner.Position).Length;
				if (entity is Explorer && currentDistance < shortestDistance)
				{
					shortestDistance = currentDistance;
					closestExplorer = (Explorer)entity;
				}
			}
		}
	}
}
