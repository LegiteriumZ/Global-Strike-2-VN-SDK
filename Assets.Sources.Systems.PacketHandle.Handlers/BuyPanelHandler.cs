using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class BuyPanelHandler : ApcPacketHandler<BuyPanelData>
{
	private GameRuleContext _gameRuleContext;

	public BuyPanelHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 88;
	}

	public override void Handle(BuyPanelData data)
	{
		_gameRuleContext.buyPanelData.PanelData = data;
		_gameRuleContext.buyPanelData.GiveWeaponIndex = 0;
		_gameRuleContext.buyPanelData.WeaponType = -1;
		_gameRuleContext.buyPanelData.WeaponIndex = -1;
	}
}
