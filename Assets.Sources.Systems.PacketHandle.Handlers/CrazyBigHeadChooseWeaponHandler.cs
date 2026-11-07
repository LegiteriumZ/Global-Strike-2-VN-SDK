using System.Collections.Generic;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class CrazyBigHeadChooseWeaponHandler : ApcPacketHandler<HeroWeaponData>
{
	private readonly GameRuleContext _gameRuleContext;

	public CrazyBigHeadChooseWeaponHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 269;
	}

	public override void Handle(HeroWeaponData data)
	{
		_gameRuleContext.crazyBigHead.HeroWeaponData = data;
		_gameRuleContext.crazyBigHead.WeaponList = new List<string> { data.WeaponKey1, data.WeaponKey2, data.WeaponKey3, data.WeaponKey4, data.WeaponKey5 };
		NotifyManager.ForceInvoke(83);
	}
}
