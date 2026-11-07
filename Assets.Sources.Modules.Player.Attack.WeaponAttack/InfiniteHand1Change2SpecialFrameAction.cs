using Assets.Sources.Modules.Player.Attack.Action;
using SSJJAsset.Asset;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class InfiniteHand1Change2SpecialFrameAction : AwmLegendSpecialFrameAction
{
	public InfiniteHand1Change2SpecialFrameAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override bool IsSkill1Active(WeaponEntity currentWeapon)
	{
		if (currentWeapon.special.SpecialMode)
		{
			return currentWeapon.basicInfo.Data.Kill > 0;
		}
		return false;
	}

	protected override AssetInfo GetMarkEffectAsset(WeaponEntity currentWeapon)
	{
		return new AssetInfo("weapon/" + currentWeapon.basicInfo.Data.WeaponName, $"Assets/Res/Assets/weapon/{currentWeapon.basicInfo.Data.WeaponName}/effect/infinite_hand_biaoji/Prefab/infinite_hand_biaoji.prefab");
	}

	protected override void MarkFailedHint()
	{
	}
}
