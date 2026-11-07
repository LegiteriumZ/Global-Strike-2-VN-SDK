using Assets.Sources.Constant.Weapon;
using NetData;

namespace Assets.Sources.Constant;

public class KillTypeConstant
{
	public const int KillDefault = 0;

	public const int WallKill = 1;

	public const int WallHeadShot = 2;

	public const int KnifeHeadShot = 3;

	public const int HeadShot = 4;

	public const int SpecialKill = 5;

	public static int GetKillType(KillPlayerInfoData info)
	{
		if (info.SpecialAttack)
		{
			return 5;
		}
		if (info.Headshot)
		{
			if (WeaponConstant.IsKnifeByName(info.WeaponName))
			{
				return 3;
			}
			if (info.Wallshot)
			{
				return 2;
			}
			return 4;
		}
		if (info.Wallshot)
		{
			return 1;
		}
		return 0;
	}
}
