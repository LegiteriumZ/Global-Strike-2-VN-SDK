using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class CrazeSkillLearnHandler : ApcPacketHandler<CrazeSkillLearn>
{
	private readonly GameRuleContext _gameRuleContext;

	public CrazeSkillLearnHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 266;
	}

	public override void Handle(CrazeSkillLearn data)
	{
		_gameRuleContext.craze.SkillLearnList = data.LvList;
		NotifyManager.ForceInvoke(80);
	}
}
