using System.Collections.Generic;
using Assets.Sources.Framework;
using NetData;

namespace Assets.Sources.Modules.SceneObject.GrenadeExplosion;

public class GrenadeExplosionEntityCreateSystem : IPlaybackInitSystem
{
	private readonly SnapshotContext _snapshotContext;

	public GrenadeExplosionEntityCreateSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
	}

	public void OnPlaybackInit()
	{
		if (_snapshotContext.snapshots.NowSnapshot == null)
		{
			return;
		}
		foreach (KeyValuePair<int, GrenadeExplosionEventEntityData> item in _snapshotContext.snapshots.NowSnapshot.GrenadeExplosionEventEntityDataDict)
		{
			GrenadeExplosionEventEntityData value = item.Value;
			SceneObjectFactory.Instance.CreateExplosion(value);
		}
	}
}
