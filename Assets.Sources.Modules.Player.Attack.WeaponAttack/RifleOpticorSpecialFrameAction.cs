using Assets.Sources.Modules.Player.Attack.Action;
using SSJJAsset.Asset;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class RifleOpticorSpecialFrameAction : AwmLegendSpecialFrameAction
{
	public RifleOpticorSpecialFrameAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override bool IsSkill1Active(WeaponEntity currentWeapon)
	{
		if (currentWeapon.special.SpecialMode)
		{
			return currentWeapon.basicInfo.Data.NextSkillTimer > 0;
		}
		return false;
	}

	protected override AssetInfo GetMarkEffectAsset(WeaponEntity currentWeapon)
	{
		return new AssetInfo("weapon/" + currentWeapon.basicInfo.Data.WeaponName, $"Assets/Res/Assets/weapon/{currentWeapon.basicInfo.Data.WeaponName}/effect/rifle_opticor_biaoji/Prefab/rifle_opticor_biaoji.prefab");
	}

	protected override void MarkFailedHint()
	{
	}
}
