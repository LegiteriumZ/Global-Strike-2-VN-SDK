using Assets.Sources.Components.Weapon;
using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class HeroBladeKnifeFrameAction : AbstractKnifeFrameAction
{
	public HeroBladeKnifeFrameAction(Contexts contexts)
	{
	}

	protected override bool CheckDelayAttack(ref CommonWeaponArg arg)
	{
		if (!arg.Player.viewAnim.Equals(15) && !arg.Player.viewAnim.Equals(40) && !arg.Player.viewAnim.Equals(31) && !arg.Player.viewAnim.Equals(69) && !arg.Player.viewAnim.Equals(29) && !arg.Player.viewAnim.Equals(71) && !arg.Player.viewAnim.Equals(20) && !arg.Player.viewAnim.Equals(72) && !arg.Player.viewAnim.Equals(28) && !arg.Player.viewAnim.Equals(96))
		{
			return false;
		}
		return true;
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		base.Action(ref arg);
		int index = 2;
		HeroBladeAttach obj = (arg.CurrentWeapon.GetComponent(index) as AttachComponent).Data as HeroBladeAttach;
		obj.oldSlashSlashTime = 1000;
		obj.oldSlashStabTime = 1000;
		obj.oldStabSlashTime = 1700;
		obj.oldStabStabTime = 1700;
		obj.oldDelayAttackSlashTime = 300;
		obj.oldDelayAttackStabTime = 650;
		getConfig(arg.CurrentWeapon.special.EffectLevel, arg.CurrentWeapon);
		if (obj.swordProtectionType == 2)
		{
			if (arg.Player.viewAnim.ViewAnimInfo.StateId == 13)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 39);
			}
			if (arg.Player.viewAnim.ViewAnimInfo.StateId == 14)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 48);
			}
		}
		else
		{
			if (arg.Player.viewAnim.ViewAnimInfo.StateId == 39)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 13);
			}
			if (arg.Player.viewAnim.ViewAnimInfo.StateId == 48)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 14);
			}
		}
		return true;
	}

	private void getConfig(long dataRec, WeaponEntity currentWeapon)
	{
		int index = 2;
		HeroBladeAttach heroBladeAttach = (currentWeapon.GetComponent(index) as AttachComponent).Data as HeroBladeAttach;
		heroBladeAttach.swordHeartType = 0;
		heroBladeAttach.swordType = 0;
		heroBladeAttach.swordProtectionType = 0;
		heroBladeAttach.swordPatternType = 0;
		if ((dataRec & 1) > 0 && (dataRec & 2) > 0)
		{
			heroBladeAttach.swordType = 1;
		}
		if ((dataRec & 4) > 0 && (dataRec & 8) > 0)
		{
			heroBladeAttach.swordType = 2;
		}
		if ((dataRec & 0x10) > 0 && (dataRec & 0x20) > 0)
		{
			heroBladeAttach.swordProtectionType = 1;
		}
		if ((dataRec & 0x40) > 0 && (dataRec & 0x80) > 0)
		{
			heroBladeAttach.swordProtectionType = 2;
		}
		if ((dataRec & 0x100) > 0 && (dataRec & 0x200) > 0)
		{
			heroBladeAttach.swordPatternType = 1;
		}
		if ((dataRec & 0x400) > 0 && (dataRec & 0x800) > 0)
		{
			heroBladeAttach.swordPatternType = 2;
		}
		if ((dataRec & 0x1000) > 0 && (dataRec & 0x2000) > 0)
		{
			heroBladeAttach.swordHeartType = 1;
		}
		if ((dataRec & 0x4000) > 0 && (dataRec & 0x8000) > 0)
		{
			heroBladeAttach.swordHeartType = 2;
		}
		if (heroBladeAttach.swordProtectionType == 1)
		{
			KnifeWeaponInfo obj = currentWeapon.basicInfo.Info as KnifeWeaponInfo;
			obj.SlashSlashTime = (int)((double)heroBladeAttach.oldSlashSlashTime * 0.8);
			obj.SlashSlashTime = (int)((double)heroBladeAttach.oldSlashSlashTime * 0.8);
			obj.SlashSlashTime = (int)((double)heroBladeAttach.oldSlashSlashTime * 0.8);
			obj.SlashSlashTime = (int)((double)heroBladeAttach.oldSlashSlashTime * 0.8);
			obj.DelayAttackSlashTime = (int)((double)heroBladeAttach.oldDelayAttackSlashTime * 0.8);
			obj.DelayAttackStabTime = (int)((double)heroBladeAttach.oldDelayAttackStabTime * 0.8);
		}
		else
		{
			KnifeWeaponInfo obj2 = currentWeapon.basicInfo.Info as KnifeWeaponInfo;
			obj2.SlashSlashTime = heroBladeAttach.oldSlashSlashTime;
			obj2.SlashSlashTime = heroBladeAttach.oldSlashSlashTime;
			obj2.SlashSlashTime = heroBladeAttach.oldSlashSlashTime;
			obj2.SlashSlashTime = heroBladeAttach.oldSlashSlashTime;
			obj2.DelayAttackSlashTime = heroBladeAttach.oldDelayAttackSlashTime;
			obj2.DelayAttackStabTime = heroBladeAttach.oldDelayAttackStabTime;
		}
	}
}
