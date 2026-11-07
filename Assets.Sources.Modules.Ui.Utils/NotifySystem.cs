using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Framework;
using NotifyEvent;
using SSJJBase.Manager;

namespace Assets.Sources.Modules.Ui.Utils;

public class NotifySystem : IPlaybackSystem
{
	private FrameSkipManager frameSkipManager = new FrameSkipManager();

	public NotifySystem(Contexts contexts)
	{
	}

	public void OnPlayback()
	{
		if (!frameSkipManager.Frame(1))
		{
			NotifyManager.Step();
			SimpleNotify.Update();
			SimpleNotify.Clear();
		}
	}
}
