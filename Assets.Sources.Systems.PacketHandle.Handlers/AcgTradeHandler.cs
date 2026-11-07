using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class AcgTradeHandler : ApcPacketHandler<InitPanelResponse>
{
	private GameRuleContext _gameRuleContext;

	public AcgTradeHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 1102;
	}

	public override void Handle(InitPanelResponse data)
	{
		_gameRuleContext.acgPowerUp.CanShow = data.CanShow;
		_gameRuleContext.acgPowerUp.ShowHeal = !data.CanGrey1;
		_gameRuleContext.acgPowerUp.ShowPowerUp = !data.CanGrey2;
		_gameRuleContext.acgPowerUp.HealPrice = data.BloodPrice;
		_gameRuleContext.acgPowerUp.PowerUpPrice = data.SkillPrice;
		NotifyManager.ForceInvoke(108);
	}
}
