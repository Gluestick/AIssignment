using ISGPAI.Game.Maths;

namespace ISGPAI.Game.Entities.GoalDrivenBehavior
{
	public class SeekGoal : Goal<Helper>
	{
		private Vector2 _target;

		public SeekGoal(Helper owner, Vector2 target)
		{
			this._owner = owner;
			this._target = target;
		}

		public override void Activate()
		{
			throw new System.NotImplementedException();
		}

		public override Status Process()
		{
			throw new System.NotImplementedException();
		}

		public override void Terminate()
		{
			throw new System.NotImplementedException();
		}

		public override void AddSubGoal(Goal<Helper> goal)
		{
			throw new System.NotImplementedException();
		}
	}
}
