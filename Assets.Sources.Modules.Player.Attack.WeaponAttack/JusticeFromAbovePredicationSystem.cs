using Assets.Sources.Modules.Player.Attack.Action;
using SSJJAsset.Asset;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class JusticeFromAbovePredicationSystem : AbstractAttackPredicationSystem
{
	internal class JusticeFromAboveFrameAction : AwmLegendSpecialFrameAction
	{
		public JusticeFromAboveFrameAction(Contexts contexts)
			: base(contexts)
		{
		}

		protected override bool IsSkill1Active(WeaponEntity currentWeapon)
		{
			if (currentWeapon.special.EffectLevel > 0)
			{
				return currentWeapon.special.SpecialMode;
			}
			return false;
		}

		protected override AssetInfo GetMarkEffectAsset(WeaponEntity currentWeapon)
		{
			return new AssetInfo("weapon/" + currentWeapon.basicInfo.Data.WeaponName, $"Assets/Res/Assets/weapon/{currentWeapon.basicInfo.Data.WeaponName}/effect/tianhuoshizhe_zhishi/Prefab/tianhuoshizhe_zhishi.prefab");
		}
	}

	public JusticeFromAbovePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new PistolIdleAction(contexts));
		FrameActions.Add(new JusticeFromAboveFrameAction(contexts));
	}
}
