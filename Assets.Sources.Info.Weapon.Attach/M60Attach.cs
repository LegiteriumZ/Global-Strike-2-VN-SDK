using Assets.Sources.Components.Weapon;

namespace Assets.Sources.Info.Weapon.Attach;

internal class M60Attach : AbstractAttach
{
	public static int GetMaxLevel(WeaponEntity weapon)
	{
		if (!weapon.basicInfo.Data.WeaponName.Equals("m60e6bloodanger"))
		{
			return 1000;
		}
		return 800;
	}
}
