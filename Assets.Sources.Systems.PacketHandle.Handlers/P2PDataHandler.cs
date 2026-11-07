using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Utils.EventLogger;
using SSJJBase.Logger;
using SSJJBase.Thread;
using SSJJNetworking.BattleServer;
using SSJJNetworking.Server;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class P2PDataHandler : IPacketHandler<P2PData>
{
	private readonly BattleServerContext _context;

	private readonly BattleRoomContext _battleGameContext;

	private bool _isUpload;

	public IPacketBodyParser<P2PData> Parser => new P2PDataParser();

	public P2PDataHandler(Contexts contexts)
	{
		_context = contexts.battleServer;
		_battleGameContext = contexts.battleRoom;
	}

	public int MethodId()
	{
		return 0;
	}

	public void Handle(P2PData data)
	{
		UnityMainThreadDispatcher.Enqueue(delegate
		{
			IBattleServer server = _context.battleServer.Server;
			if (!server.UdpSnapshotSpliced)
			{
				server.UdpSnapshotSpliced = data.UdpSnapshotSpliced;
			}
			server.UdpSnapshotCompressed = data.UdpSnapshotCompressed;
			server.UdpSnapshotCompressed = true;
			server.UdpSize = data.UdpSize;
			server.NewUdpProtocal = true;
			if (_battleGameContext.gameState.State == BattleGameState.WaitingP2P)
			{
				_battleGameContext.gameState.State = BattleGameState.WaitingSnapshot;
				if (!_isUpload)
				{
					_isUpload = true;
					GlobalProperties.Instance.Properties["UdpSnapShot0"] = 1;
					EventLogger.Instance.StageLogger("P2PDataHandler Receive, Connect Udp For SnapShot", StartStageEnum.LoadSnapShot);
				}
			}
		});
	}
}
