using Assets.Sources.Free.Weapon;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class WeaponListLoadHandler : ApcPacketHandler<FreeWeaponListData>
{
	public WeaponListLoadHandler(Contexts contexts)
	{
	}

	public override int MethodId()
	{
		return 331;
	}

	public override void Handle(FreeWeaponListData data)
	{
		for (int i = 0; i < data.AllWeaponList.Count; i++)
		{
			FreeWeaponConfigData freeWeaponConfigData = data.AllWeaponList[i];
			FreeWeaponConfig freeWeaponConfig = new FreeWeaponConfig();
			if (freeWeaponConfigData.WeaponKeySpecified)
			{
				freeWeaponConfig.WeaponKey = freeWeaponConfigData.WeaponKey;
			}
			if (freeWeaponConfigData.WeaponTypeSpecified)
			{
				freeWeaponConfig.WeaponType = freeWeaponConfigData.WeaponType;
			}
			if (freeWeaponConfigData.WeaponNameSpecified)
			{
				freeWeaponConfig.WeaponName = freeWeaponConfigData.WeaponName;
			}
			if (freeWeaponConfigData.CodeClientSpecified)
			{
				freeWeaponConfig.CodeClient = freeWeaponConfigData.CodeClient;
			}
			if (freeWeaponConfigData.WeaponAniNameSpecified)
			{
				freeWeaponConfig.WeaponAniName = freeWeaponConfigData.WeaponAniName;
			}
			if (freeWeaponConfigData.ThirdAniDefSpecified)
			{
				freeWeaponConfig.ThirdAniDef = freeWeaponConfigData.ThirdAniDef;
			}
			if (freeWeaponConfigData.DefaultWeaponSpecified)
			{
				freeWeaponConfig.DefaultWeapon = freeWeaponConfigData.DefaultWeapon;
			}
			if (freeWeaponConfigData.HeroThirdAnimDefSpecified)
			{
				freeWeaponConfig.HeroThirdAnimDef = freeWeaponConfigData.HeroThirdAnimDef;
			}
			if (!FreeWeaponManager.WeaponConfigs.ContainsKey(freeWeaponConfig.WeaponKey))
			{
				FreeWeaponManager.WeaponConfigs.Add(freeWeaponConfig.WeaponKey, freeWeaponConfig);
			}
		}
	}
}
