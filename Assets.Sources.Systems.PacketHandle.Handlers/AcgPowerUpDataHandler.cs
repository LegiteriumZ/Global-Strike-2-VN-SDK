using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class AcgPowerUpDataHandler : ApcPacketHandler<BENEFITPUSH>
{
	private GameRuleContext _gameRuleContext;

	public AcgPowerUpDataHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 1105;
	}

	public override void Handle(BENEFITPUSH data)
	{
		_gameRuleContext.acgPowerUp.OwnedList = data.SkillList;
		NotifyManager.ForceInvoke(109);
	}
}
