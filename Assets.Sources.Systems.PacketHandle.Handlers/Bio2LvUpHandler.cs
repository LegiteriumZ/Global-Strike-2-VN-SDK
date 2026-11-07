using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class Bio2LvUpHandler : ApcPacketHandler<Bio2LvUpData>
{
	private GameRuleContext _gameRuleContext;

	public Bio2LvUpHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 106;
	}

	public override void Handle(Bio2LvUpData data)
	{
		_gameRuleContext.bio2SkillLvUpData.Lv = data.Lv;
		_gameRuleContext.bio2SkillLvUpData.Exp = data.Exp;
		_gameRuleContext.bio2SkillLvUpData.LvUpExp = data.LvUpExp;
		_gameRuleContext.bio2SkillLvUpData.SkillCount = data.SkillCount;
	}
}
