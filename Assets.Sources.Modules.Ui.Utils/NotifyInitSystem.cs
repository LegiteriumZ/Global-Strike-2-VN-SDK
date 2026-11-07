using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;

namespace Assets.Sources.Modules.Ui.Utils;

public class NotifyInitSystem : IPlaybackSystem
{
	public NotifyInitSystem(Contexts contexts)
	{
	}

	public void OnPlayback()
	{
		UiIEventCondition.Init();
	}
}
