using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class BioLvUpHandler : ApcPacketHandler<BioLvUpData>
{
	private GameRuleContext _gameRuleContext;

	public BioLvUpHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 83;
	}

	public override void Handle(BioLvUpData data)
	{
		_gameRuleContext.bioNewVariantsGrowUp.LvUpHp = data.LvUpAddHp;
		_gameRuleContext.bioNewVariantsGrowUp.Lv = data.Lv;
		_gameRuleContext.bioNewVariantsGrowUp.IsLvUpDead = data.DeadLvUp;
	}
}
