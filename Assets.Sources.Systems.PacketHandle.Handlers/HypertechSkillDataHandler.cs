using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class HypertechSkillDataHandler : ApcPacketHandler<HypertechData>
{
	private GameRuleContext _gameRuleContext;

	public HypertechSkillDataHandler(Contexts context)
	{
		_gameRuleContext = context.gameRule;
	}

	public override int MethodId()
	{
		return 600;
	}

	public override void Handle(HypertechData data)
	{
		_gameRuleContext.hypertechData._canUseSkill = data.CanUseSkill;
		_gameRuleContext.hypertechData._durationTime = data.DurationTime;
	}
}
