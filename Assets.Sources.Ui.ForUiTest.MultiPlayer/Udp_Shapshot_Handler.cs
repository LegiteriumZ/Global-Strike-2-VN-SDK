using System;
using Assets.Sources.Snapshots;
using Assets.Sources.Systems.PacketHandle;
using SSJJBase.Extensions;
using SSJJBase.Thread;
using SSJJNetworking.Server;

namespace Assets.Sources.Ui.ForUiTest.MultiPlayer;

public class Udp_Shapshot_Handler : IPacketHandler<Snapshot>
{
	private MultiPlayerBattleServer _server;

	public IPacketBodyParser<Snapshot> Parser => new UdpSnapshotParser();

	public Udp_Shapshot_Handler(MultiPlayerBattleServer server)
	{
		_server = server;
	}

	public int MethodId()
	{
		return 1;
	}

	public void Handle(Snapshot snapshot)
	{
		UnityMainThreadDispatcher.Enqueue(delegate
		{
			_server.PartialSnapshots.Add(snapshot);
			_server.ReceiveSnapshotTime = DateTime.Now;
			_server.PlayerData = EntityDataExtension.ClonePlayerEntityData(snapshot.PlayerEntityDataDict[snapshot.Self], _server.PlayerData);
		});
	}
}
