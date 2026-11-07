using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class HeroFightingMessageHandler : ApcPacketHandler<SimpleBuffDiffData>
{
	private GameRuleContext _gameRuleContext;

	public HeroFightingMessageHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 605;
	}

	public override void Handle(SimpleBuffDiffData data)
	{
		Contexts.sharedInstance.message.heroFightingBuffShow.BuffEvent.Add(data);
		NotifyManager.ForceInvoke(119);
	}
}
