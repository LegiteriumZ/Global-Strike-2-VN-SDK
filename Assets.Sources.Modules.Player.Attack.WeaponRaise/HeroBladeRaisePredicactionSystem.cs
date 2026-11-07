using Assets.Sources.Components.Weapon;
using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Info.Weapon.WeaponInfo;
using Assets.Sources.Modules.Player.Attack.WeaponAttack;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponRaise;

internal class HeroBladeRaisePredicactionSystem : AbstractRaisePredicactionSystem
{
	private HeroBladeKnifeRightAction _action;

	public HeroBladeRaisePredicactionSystem(Contexts contexts)
		: base(contexts)
	{
		_action = new HeroBladeKnifeRightAction(contexts);
	}

	protected override int GetRaiseAdminId(PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd)
	{
		int index = 2;
		if (((currentWeapon.GetComponent(index) as AttachComponent).Data as HeroBladeAttach).swordProtectionType == 2)
		{
			return 47;
		}
		return 16;
	}

	protected override void SetRaiseAnim(PlayerEntity player, WeaponEntity currentWeapon, WeaponEntity lastWeapon, IUserCmd cmd)
	{
		int raiseAdminId = GetRaiseAdminId(player, currentWeapon, cmd);
		PlayerAnimationUtility.SetViewAnimation(player, raiseAdminId);
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, raiseAdminId);
		int index = 2;
		HeroBladeAttach obj = (currentWeapon.GetComponent(index) as AttachComponent).Data as HeroBladeAttach;
		if (obj.swordProtectionType == 1)
		{
			player.viewAnim.RightSpeed = 1.2f;
		}
		else
		{
			player.viewAnim.RightSpeed = 1f;
		}
		viewAnimDuration = (int)((float)viewAnimDuration / player.viewAnim.RightSpeed);
		currentWeapon.attack.NextAttackTimer = player.clientTime.ClientTime + viewAnimDuration;
		currentWeapon.attack.NextSecondaryAttackTimer = player.clientTime.ClientTime + viewAnimDuration;
		if (obj.swordPatternType == 1)
		{
			_ = currentWeapon.basicInfo.Info;
			DefaultWeaponInfo defaultWeaponInfo = currentWeapon.basicInfo.Info as DefaultWeaponInfo;
			int index2 = 2;
			if (currentWeapon.GetComponent(index2) is AttachComponent attachComponent)
			{
				HeroBladeAttach heroBladeAttach = attachComponent.Data as HeroBladeAttach;
				float num = 0f;
				num = ((heroBladeAttach == null || !heroBladeAttach.sweep) ? defaultWeaponInfo.ShotDistanceLogic.GetShotDistance(cmd, currentWeapon, isMelee: false) : defaultWeaponInfo.ShotDistanceLogic.GetShotDistance(cmd, currentWeapon, isMelee: true));
				SetNewAttackAnim(player, cmd, currentWeapon);
				CommonWeaponArg arg = default(CommonWeaponArg);
				arg.CurrentWeapon = currentWeapon;
				arg.Player = player;
				arg.ClientTime = player.clientTime.ClientTime;
				arg.Cmd = cmd;
				arg.Contexts = Contexts.sharedInstance;
				_action.KnifeFire(ref arg, cmd.Seq, num, FireUtility.PlaySecFireSound);
			}
		}
	}

	protected override float GetNextWeaponRaisedSpeed(PlayerEntity player, WeaponEntity currentWeaponEntity, WeaponEntity nextWeaponEntity)
	{
		if (currentWeaponEntity == null)
		{
			return 1f;
		}
		int index = 2;
		if (currentWeaponEntity.GetComponent(index) is AttachComponent { Data: HeroBladeAttach { swordProtectionType: >0 } })
		{
			return 1.2f;
		}
		return 1f;
	}

	protected void SetNewAttackAnim(PlayerEntity player, IUserCmd cmd, WeaponEntity currentWeapon)
	{
		int index = 2;
		if (!(currentWeapon.GetComponent(index) is AttachComponent attachComponent))
		{
			return;
		}
		HeroBladeAttach heroBladeAttach = attachComponent.Data as HeroBladeAttach;
		if (heroBladeAttach.swordProtectionType == 2)
		{
			heroBladeAttach.sweep = true;
		}
		else
		{
			heroBladeAttach.sweep = false;
		}
		if (heroBladeAttach.swordType == 1 || heroBladeAttach.swordType == 0)
		{
			if (heroBladeAttach.swordProtectionType == 1 || heroBladeAttach.swordProtectionType == 0)
			{
				PlayerAnimationUtility.SetViewAnimation(player, 20);
				PlayerAnimationUtility.SetTorseAnimation(player, 15);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(player, 72);
				PlayerAnimationUtility.SetTorseAnimation(player, 15);
			}
		}
		if (heroBladeAttach.swordType == 2)
		{
			if (heroBladeAttach.swordProtectionType == 2)
			{
				PlayerAnimationUtility.SetViewAnimation(player, 96);
				PlayerAnimationUtility.SetTorseAnimation(player, 15);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(player, 28);
				PlayerAnimationUtility.SetTorseAnimation(player, 15);
			}
		}
		if (heroBladeAttach.swordProtectionType == 1)
		{
			player.viewAnim.RightSpeed = 1.2f;
		}
		else
		{
			player.viewAnim.RightSpeed = 1f;
		}
	}
}
