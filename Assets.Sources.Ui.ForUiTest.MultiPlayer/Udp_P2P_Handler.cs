using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Systems.PacketHandle;
using Assets.Sources.Systems.PacketHandle.Handlers;
using SSJJBase.Thread;
using SSJJNetworking.Server;

namespace Assets.Sources.Ui.ForUiTest.MultiPlayer;

public class Udp_P2P_Handler : IPacketHandler<P2PData>
{
	private MultiPlayerBattleServer _server;

	public IPacketBodyParser<P2PData> Parser => new P2PDataParser();

	public Udp_P2P_Handler(MultiPlayerBattleServer server)
	{
		_server = server;
	}

	public int MethodId()
	{
		return 0;
	}

	public void Handle(P2PData data)
	{
		UnityMainThreadDispatcher.Enqueue(delegate
		{
			_server.UdpSnapshotSpliced = data.UdpSnapshotSpliced;
			_server.UdpSnapshotCompressed = data.UdpSnapshotCompressed;
			_server.UdpSnapshotCompressed = true;
			_server.UdpSize = data.UdpSize;
			_server.NewUdpProtocal = true;
			if (_server.GameState == BattleGameState.WaitingP2P)
			{
				_server.GameState = BattleGameState.WaitingSnapshot;
			}
		});
	}
}
