using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgMouseYearChooseWeaponPushResponseHandler : ApcPacketHandler<ChooseWeaponPushResponse>
{
	private readonly GameRuleContext _gameRuleContext;

	public RpgMouseYearChooseWeaponPushResponseHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 252;
	}

	public override void Handle(ChooseWeaponPushResponse data)
	{
		if (!_gameRuleContext.hasChooseWeapon)
		{
			return;
		}
		_gameRuleContext.chooseWeapon.ChooseWeaponChanged = true;
		foreach (WeaponTypeEntity entity in _gameRuleContext.chooseWeapon.ChooseWeaponUiResponse.EntityList)
		{
			if (entity.Type == data.Type)
			{
				entity.IsChoose = true;
			}
		}
	}
}
