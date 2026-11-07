using System;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Components.BattleServer;
using Assets.Sources.Utils;
using Entitas;
using SSJJBase.Logger;
using SSJJNetworking.BattleServer;

namespace Assets.Sources.Systems.PacketHandle;

public class SendP2PPackageSystem : IExecuteSystem, ISystem
{
	public static IRecord Record;

	private readonly BattleServerContext _context;

	private readonly BattleRoomContext _battleGameContext;

	private int _tryCount;

	private int MAX_TRY_COUNT = 14;

	public SendP2PPackageSystem(Contexts contexts)
	{
		_context = contexts.battleServer;
		_battleGameContext = contexts.battleRoom;
	}

	private bool RecordPlaying()
	{
		if (Record != null)
		{
			return Record.IsPlaying();
		}
		return false;
	}

	public void Execute()
	{
		if (GameController.Instance == null)
		{
			return;
		}
		BattleServerComponent battleServer = _context.battleServer;
		BattleGameState state = _battleGameContext.gameState.State;
		if ((battleServer.Server.State != BattleServerState.Connected && !RecordPlaying()) || (state != BattleGameState.WaitingP2P && state != BattleGameState.WaitingSnapshot) || !((DateTime.Now - battleServer.LastSendP2PTime).TotalMilliseconds > 500.0))
		{
			return;
		}
		_tryCount++;
		if (_tryCount == MAX_TRY_COUNT && state == BattleGameState.WaitingP2P)
		{
			battleServer.Server.ForceUseTcp();
		}
		else if (!battleServer.Server.IsDefaultUseTcp)
		{
			if (!battleServer.Server.NewUdpProtocal)
			{
				this.Info("Send P2P Data Connect ...");
			}
			battleServer.Server.SendUdpP2PData(0, splice: true, compress: false);
			battleServer.LastSendP2PTime = DateTime.Now;
		}
		else if (state == BattleGameState.WaitingP2P)
		{
			_battleGameContext.gameState.State = BattleGameState.WaitingSnapshot;
		}
	}
}
