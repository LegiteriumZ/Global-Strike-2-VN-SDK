using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.Chat;

namespace Assets.Sources.Modules.Ui.Message;

public class UiCommonChatModule : GameModule
{
	public UiCommonChatModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new ChatJobSystem(contexts));
	}
}
