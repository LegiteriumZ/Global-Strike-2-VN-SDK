using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgMouseYearChooseWeaponTypeResponseHandler : ApcPacketHandler<ChooseWeaponTypeResponse>
{
	private GameRuleContext _gameRuleContext;

	public RpgMouseYearChooseWeaponTypeResponseHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 251;
	}

	public override void Handle(ChooseWeaponTypeResponse data)
	{
		if (_gameRuleContext.hasChooseWeapon)
		{
			if (data.ErrorCode == 1)
			{
				_gameRuleContext.chooseWeapon.CanChooseWeapon = false;
			}
			else if (data.ErrorCode == 2)
			{
				_gameRuleContext.chooseWeapon.HaveChoosedWeapon = false;
			}
			else if (data.ErrorCode == 3)
			{
				_gameRuleContext.chooseWeapon.CanChooseWeapon = false;
			}
		}
	}
}
