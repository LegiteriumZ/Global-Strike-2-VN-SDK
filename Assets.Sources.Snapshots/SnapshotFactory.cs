using SSJJBase.Pool;

namespace Assets.Sources.Snapshots;

public class SnapshotFactory
{
	public static SnapshotFactory Instance = new SnapshotFactory();

	private readonly StackObjectPool<Snapshot> _snapshotPool = new StackObjectPool<Snapshot>();

	private readonly object _lockObject = new object();

	public Snapshot GetOrCreate()
	{
		lock (_lockObject)
		{
			Snapshot snapshot = _snapshotPool.GetOrNull();
			if (snapshot == null)
			{
				snapshot = new Snapshot();
			}
			snapshot.Reset();
			snapshot.ResetEntities();
			return snapshot;
		}
	}

	public void Add(Snapshot snapshot)
	{
		lock (_lockObject)
		{
			_snapshotPool.Add(snapshot);
		}
	}

	public void Clear()
	{
		for (int i = 0; i < _snapshotPool.Count(); i++)
		{
			Snapshot orNull = _snapshotPool.GetOrNull();
			if (orNull != null)
			{
				orNull.ResetEntities();
				orNull.Reset();
			}
		}
	}
}
