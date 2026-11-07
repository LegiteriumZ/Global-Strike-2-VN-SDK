using System;
using Entitas;
using SSJJBase.Logger;
using SSJJNetworking.BattleServer;

namespace Assets.Sources.Systems.PacketHandle;

public class BattleServerErrorHandleSystem : IInitializeSystem, ISystem
{
	private readonly BattleServerContext _context;

	public BattleServerErrorHandleSystem(Contexts contexts)
	{
		_context = contexts.battleServer;
	}

	public void Initialize()
	{
		IBattleServer server = _context.battleServer.Server;
		server.ConnectEvent = (BattleServerConnectDelegate)Delegate.Combine(server.ConnectEvent, (BattleServerConnectDelegate)delegate(int code, string message)
		{
			if (code != 0)
			{
				this.LogErrorFormat("BattleServer Connect Error code {0} msg {1}", code, message);
			}
		});
		server.DisconnectEvent = (BattleServerDisconnectDelegate)Delegate.Combine(server.DisconnectEvent, (BattleServerDisconnectDelegate)delegate(CloseType code, string message)
		{
			this.LogErrorFormat("BattleServer Disconnect Error code {0} msg {1}", code, message);
		});
	}
}
