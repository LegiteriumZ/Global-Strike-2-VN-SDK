using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;
using SSJJAsset.Asset;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class SelfDisciplineGunPredicationSystem : AbstractAttackPredicationSystem
{
	internal class SelfDisciplineGunFrameAction : AwmLegendSpecialFrameAction
	{
		public SelfDisciplineGunFrameAction(Contexts contexts)
			: base(contexts)
		{
		}

		public override bool Action(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.IsShowGun && arg.CurrentWeapon.clip.Clip2 == 1 && arg.CurrentWeapon.clip.CarryClip2 == 1)
			{
				Contexts.sharedInstance.message.messageRemindData.SetMessage(ScriptLocalization.Get("RPG_ZIWEISHOUWEI_V_USE"));
				NotifyManager.ForceInvoke(38);
			}
			if (IsSkill1Active(arg.CurrentWeapon))
			{
				MouseLogic(arg.Player, arg.CurrentWeapon);
			}
			return true;
		}

		protected override bool IsSkill1Active(WeaponEntity currentWeapon)
		{
			return currentWeapon.basicInfo.Data.Kill > 0;
		}

		protected override void MarkFailedHint()
		{
		}

		protected override AssetInfo GetMarkEffectAsset(WeaponEntity currentWeapon)
		{
			return new AssetInfo("weapon/" + currentWeapon.basicInfo.Data.WeaponName, $"Assets/Res/Assets/weapon/{currentWeapon.basicInfo.Data.WeaponName}/effect/zilvshouwei_biaoji/Prefab/zilvshouwei_biaoji.prefab");
		}
	}

	public SelfDisciplineGunPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new PistolIdleAction(contexts));
		FrameActions.Add(new SelfDisciplineGunFrameAction(contexts));
	}
}
