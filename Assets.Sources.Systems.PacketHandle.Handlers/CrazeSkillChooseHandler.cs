using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class CrazeSkillChooseHandler : ApcPacketHandler<CrazeSkillChose>
{
	private readonly GameRuleContext _gameRuleContext;

	public CrazeSkillChooseHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 267;
	}

	public override void Handle(CrazeSkillChose data)
	{
		_gameRuleContext.craze.SkillChoseData = data.SkillList;
		NotifyManager.ForceInvoke(81);
	}
}
