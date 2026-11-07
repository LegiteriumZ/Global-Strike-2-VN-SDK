using Assets.Sources.Framework;
using Assets.Sources.Free.UI;
using SSJJBase.Singleton;

namespace Assets.Sources.Free;

public class FreeFrameSystem : IPlaybackSystem
{
	public void OnPlayback()
	{
		MonoBehaviourSingleton<SimpleUIUpdater>.Instance.OnPlayback();
		MonoBehaviourSingleton<FreeUiManager>.Instance.OnPlayback();
	}
}
