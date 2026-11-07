using Assets.Sources.Snapshots;
using Assets.Sources.Utils;
using SSJJBase.Logger;
using SSJJBase.Thread;
using SSJJNetworking.Server;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class SnapshotPacketHandler : IPacketHandler<Assets.Sources.Snapshots.Snapshot>
{
	private int _reciveIndex;

	private readonly SnapshotContext _snapShotContext;

	private readonly BattleServerContext _battleServerContext;

	public static IRecord Record;

	public IPacketBodyParser<Assets.Sources.Snapshots.Snapshot> Parser => new UdpSnapshotParser();

	public SnapshotPacketHandler(Contexts contexts)
	{
		_snapShotContext = contexts.snapshot;
		_battleServerContext = contexts.battleServer;
	}

	public int MethodId()
	{
		return 1;
	}

	public void Handle(Assets.Sources.Snapshots.Snapshot snapshot)
	{
		if (snapshot == null)
		{
			return;
		}
		UnityMainThreadDispatcher.Enqueue(delegate
		{
			if (_reciveIndex == 0)
			{
				_reciveIndex++;
				this.Info("Have Received Snapshot");
			}
			_snapShotContext.snapshots.PartialSnapshots.Add(snapshot);
		});
	}
}
