using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class ShowWeaponListHandler : ApcPacketHandler<KingOfGunShowWeaponListData>
{
	private GameRuleContext _gameRuleContext;

	public ShowWeaponListHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 47;
	}

	public override void Handle(KingOfGunShowWeaponListData data)
	{
		_gameRuleContext.selectWeapon.SecondWeaponNameList = data.WeaponNames2;
		_gameRuleContext.selectWeapon.WeaponNameList = data.WeaponNames;
	}
}
