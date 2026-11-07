using Assets.Sources.Info.Weapon;
using SSJJAnim.Weapon;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Utils;

internal class ResourceUtility
{
	public static AssetInfo GetKnifeAttackEffectFristRequest(string weapon, WeaponSkinInfo weaponSkin)
	{
		if (weaponSkin == null || !weaponSkin.HasKnifeEffect)
		{
			IWeaponInfo weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(weapon);
			return new AssetInfo(weaponInfo.AssetBundleName, weaponInfo.FirstKnifeAssetName, typeof(GameObject), optional: true);
		}
		return weaponSkin.GetKnifeFirstAttackAsset(weapon);
	}

	public static AssetInfo GetKnifeAttackEffectThirdRequest(string weapon, WeaponSkinInfo weaponSkin)
	{
		if (weaponSkin == null || !weaponSkin.HasKnifeEffect)
		{
			IWeaponInfo weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(weapon);
			return new AssetInfo(weaponInfo.AssetBundleName, weaponInfo.ThirdKnifeAssetName, typeof(GameObject), optional: true);
		}
		return weaponSkin.GetKnifeThirdAttackAsset(weapon);
	}

	public static AssetInfo GetSparyRequest(int resId)
	{
		return new AssetInfo("effectprefab/spary", $"{resId}", typeof(GameObject));
	}
}
