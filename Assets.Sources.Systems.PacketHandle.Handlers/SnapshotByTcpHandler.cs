using Assets.Sources.Snapshots;
using SSJJBase.Thread;
using SSJJNetworking.Server;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class SnapshotByTcpHandler : IPacketHandler<Assets.Sources.Snapshots.Snapshot>
{
	private readonly SnapshotContext _snapshotContext;

	public IPacketBodyParser<Assets.Sources.Snapshots.Snapshot> Parser => new TcpSnapshotParser();

	public SnapshotByTcpHandler(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
	}

	public int MethodId()
	{
		return 2;
	}

	public void Handle(Assets.Sources.Snapshots.Snapshot snapshot)
	{
		if (snapshot != null)
		{
			UnityMainThreadDispatcher.Enqueue(delegate
			{
				_snapshotContext.snapshots.PartialSnapshots.Add(snapshot);
			});
		}
	}
}
