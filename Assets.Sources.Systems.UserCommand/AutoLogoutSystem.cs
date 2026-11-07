using Entitas;
using SSJJBase.Logger;
using SSJJNetworking.BattleServer;

namespace Assets.Sources.Systems.UserCommand;

public class AutoLogoutSystem : IExecuteSystem, ISystem
{
	private readonly LoggerAdapter _loggerAdapter = new LoggerAdapter(typeof(AutoLogoutSystem));

	private readonly BattleServerContext _battleServerContext;

	private readonly BattleRoomContext _battleRoomContext;

	public AutoLogoutSystem(Contexts contexts)
	{
		_battleServerContext = contexts.battleServer;
		_battleRoomContext = contexts.battleRoom;
	}

	public void Execute()
	{
		IBattleServer server = _battleServerContext.battleServer.Server;
		if (server != null && server.State == BattleServerState.Connected && _battleRoomContext.gameState.LoadingFinish)
		{
			_ = _battleRoomContext.gameState.InputDetectEnabled;
		}
	}
}
