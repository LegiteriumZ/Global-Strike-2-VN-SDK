using Entitas;

namespace Assets.Sources.Systems.PacketHandle;

public class BattleServerUpdateSystem : IExecuteSystem, ISystem
{
	private BattleServerContext _context;

	public BattleServerUpdateSystem(BattleServerContext context)
	{
		_context = context;
	}

	public void Execute()
	{
		if (_context.hasBattleServer)
		{
			_context.battleServer.Server.Update();
		}
	}
}
