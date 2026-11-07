using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class HeroSelectPanelHandle : ApcPacketHandler<SelectZombieData>
{
	private GameRuleContext _gameRuleContext;

	public HeroSelectPanelHandle(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 345;
	}

	public override void Handle(SelectZombieData data)
	{
		_gameRuleContext.selectZombie.Data = data;
		_gameRuleContext.selectZombie.Time = 10000;
	}
}
