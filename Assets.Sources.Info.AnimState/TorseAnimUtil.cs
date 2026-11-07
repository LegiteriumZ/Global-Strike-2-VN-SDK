using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Utils.Weapon;
using share.constant;

namespace Assets.Sources.Info.AnimState;

public class TorseAnimUtil
{
	public static string GetTorseAnimationName(string careerName, ICollection<string> animSeq, int torseAnim, IEntitsWeaponInfo weaponInfo, int duckState = 3)
	{
		bool isDuck = duckState == 0;
		string weaponName = WeaponUtility.GetWeaponAnimConvertHelper(weaponInfo, weaponInfo.ThirdAnimations[0]);
		if (weaponInfo.SpecialThirdAnimationTypeDict.ContainsKey(torseAnim))
		{
			weaponName = weaponInfo.SpecialThirdAnimationTypeDict[torseAnim];
		}
		if (!PlayerCareerUtil.IsTPS(careerName))
		{
			return AnimationConstantUtility.GetTorsoAnimBlendString(animSeq, torseAnim, weaponName, isDuck);
		}
		return AnimationConstantUtility.GetTpsTorsoAnimBlendString(animSeq, torseAnim, weaponName, isDuck);
	}
}
