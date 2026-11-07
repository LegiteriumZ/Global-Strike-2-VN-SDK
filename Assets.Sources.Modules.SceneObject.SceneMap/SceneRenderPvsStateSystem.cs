using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using SSJJSceneLoader;

namespace Assets.Sources.Modules.SceneObject.SceneMap;

public class SceneRenderPvsStateSystem : IPlaybackSystem
{
	private SnapshotContext snapContext;

	public SceneRenderPvsStateSystem(Contexts contexts)
	{
		snapContext = contexts.snapshot;
	}

	public void OnPlayback()
	{
		ISnapshot nowSnapshot = snapContext.snapshots.NowSnapshot;
		BaseSceneRender.GameHasPvs = true;
		if (nowSnapshot != null && nowSnapshot.ControlId > 0 && nowSnapshot.CameraEntityDataDict.ContainsKey(nowSnapshot.ControlId))
		{
			BaseSceneRender.GameHasPvs = false;
		}
	}
}
