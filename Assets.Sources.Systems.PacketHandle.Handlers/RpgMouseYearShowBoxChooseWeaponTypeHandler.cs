using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgMouseYearShowBoxChooseWeaponTypeHandler : ApcPacketHandler<ShowBaoxiangChooseWeaponTypeUI>
{
	private readonly GameRuleContext _gameRuleContext;

	public RpgMouseYearShowBoxChooseWeaponTypeHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 256;
	}

	public override void Handle(ShowBaoxiangChooseWeaponTypeUI data)
	{
		_gameRuleContext.mouseYear.ChooseDropWeapon = true;
	}
}
