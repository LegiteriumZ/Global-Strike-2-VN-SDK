using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class UltChallengeMessageHandler : ApcPacketHandler<UltChallenge>
{
	private GameRuleContext _gameRuleContext;

	public UltChallengeMessageHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 604;
	}

	public override void Handle(UltChallenge data)
	{
		if (data.EventId == 6)
		{
			Contexts.sharedInstance.message.ultimatechallenge2.killInitiative = data.Ins[0];
			Contexts.sharedInstance.message.ultimatechallenge2.killPassive = data.Ins[1];
		}
		if (data.EventId == 11)
		{
			Contexts.sharedInstance.message.ultimatechallenge2.gameStage = 1;
		}
		else if (data.EventId == 3)
		{
			Contexts.sharedInstance.message.ultimatechallenge2.gameStage = 0;
		}
		Contexts.sharedInstance.message.ultimatechallenge2.MessageEvent.Add(data);
		NotifyManager.ForceInvoke(118);
	}
}
