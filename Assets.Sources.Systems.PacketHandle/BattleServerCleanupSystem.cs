using Entitas;
using SSJJBase.Logger;

namespace Assets.Sources.Systems.PacketHandle;

public class BattleServerCleanupSystem : ICleanupSystem, ISystem
{
	private readonly LoggerAdapter _loggerAdapter = new LoggerAdapter(typeof(BattleServerCleanupSystem));

	private readonly BattleServerContext _context;

	public BattleServerCleanupSystem(Contexts contexts)
	{
		_context = contexts.battleServer;
	}

	public void Cleanup()
	{
		if (_context.hasBattleServer && _context.battleServer.Server != null)
		{
			_loggerAdapter.Info("Game Self Desotry, BattleServer Clean Up, LogOut");
			_context.battleServer.Server.Disconnect();
			_context.RemoveBattleServer();
		}
	}
}
