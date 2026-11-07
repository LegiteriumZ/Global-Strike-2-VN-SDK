using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgMouseYearShowChooseWeaponUiResponseHandler : ApcPacketHandler<ShowChooseWeaponUIResponse>
{
	private readonly GameRuleContext _gameRuleContext;

	public RpgMouseYearShowChooseWeaponUiResponseHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 250;
	}

	public override void Handle(ShowChooseWeaponUIResponse data)
	{
		_gameRuleContext.chooseWeapon.ChooseWeaponUiResponse = data;
		_gameRuleContext.chooseWeapon.CanChooseWeapon = true;
		_gameRuleContext.chooseWeapon.ChooseLeftTime = 10000;
	}
}
