using System.Collections.Generic;

namespace ISGPAI.Game.Entities.GoalDrivenBehavior
{
	public abstract class CompositeGoal<T> : Goal<T>
		where T : Entity
	{
		protected Stack<Goal<T>> _subGoals = new Stack<Goal<T>>();

		public override void AddSubGoal(Goal<T> goal)
		{
			_subGoals.Push(goal);
		}

		public Status ProcessSubGoals()
		{
			// Terminate and remove the current subgoal if completed/failed.
			while (_subGoals.Count > 0 &&
				(_subGoals.Peek().IsCompleted() || _subGoals.Peek().HasFailed()))
			{
				_subGoals.Peek().Terminate();
				_subGoals.Pop();
			}
			// Process current subgoal if there is any.
			if (_subGoals.Count > 0)
			{
				Status statusOfSubGoal = _subGoals.Peek().Process();

				// If we completed our current subgoal but still have more to go,
				// notify our parent goal that we're not done yet.
				if (statusOfSubGoal == Status.Completed && _subGoals.Count > 1)
				{
					return Status.Active;
				}
				return statusOfSubGoal;
			}
			// No subgoals left.
			return Status.Completed;
		}

		public void RemoveAllSubgoals()
		{
			_subGoals.Clear();
		}

		protected void ActivateIfInactive()
		{
			if (_status == Status.Inactive)
			{
				Activate();
			}
		}

		protected void ReactivateIfFailed()
		{
			if (_status == Status.Failed)
			{
				Activate();
			}
		}
	}
}
