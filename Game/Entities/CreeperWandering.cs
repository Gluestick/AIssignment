using System.Diagnostics;
namespace ISGPAI.Game.Entities
{
	/// <summary>
	/// Creeper state when there is no adventurer nearby.
	/// </summary>
	internal class CreeperWandering : State<Creeper>
	{
		private World _world;

		public CreeperWandering(Creeper agent, World world)
			: base(agent)
		{
			this._world = world;
		}

		public override void Enter()
		{
			Debug.WriteLine("Creeper {0} starts wandering.", _agent.Id);
		}

		public override void Update(double elapsed)
		{
		}

		public override void Exit()
		{
			Debug.WriteLine("Creeper {0} found target {1}. Start seeking.",
				_agent.Id, "TODO");
		}
	}
}
