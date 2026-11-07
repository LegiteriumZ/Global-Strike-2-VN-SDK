using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class ShowHpTypeHandler : ApcPacketHandler<HpTypeData>
{
	private GameRuleContext _gameRuleContext;

	public ShowHpTypeHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 70;
	}

	public override void Handle(HpTypeData data)
	{
		if (data.Type == ShowHpType.BOSS)
		{
			_gameRuleContext.hpProgressData.BossId = data.Id;
		}
		else if (data.Type == ShowHpType.TOWER)
		{
			_gameRuleContext.hpProgressData.HomeId = data.Id;
		}
	}
}
