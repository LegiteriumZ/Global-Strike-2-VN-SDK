using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponRaise;

internal class GlockRedflashRaisePrediactionSystem : AbstractRaisePredicactionSystem
{
	public GlockRedflashRaisePrediactionSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override int GetRaiseAdminId(PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd)
	{
		WeaponEntity weaponAtSlot = WeaponUtility.GetWeaponAtSlot(player, player.basicInfo.Current.CurrentBagId, 1, 0);
		int num = 1;
		bool changeClip = false;
		if (weaponAtSlot != null)
		{
			switch (weaponAtSlot.basicInfo.Info.WeaponType)
			{
			case 5:
				num = 2;
				break;
			case 6:
				num = 4;
				break;
			}
		}
		if (currentWeapon.special.EffectLevel != num)
		{
			if (currentWeapon.special.EffectLevel == 2 || num == 2)
			{
				changeClip = true;
			}
			currentWeapon.special.EffectLevel = num;
		}
		return GetTorsoRaiseAnim(player, currentWeapon, changeClip);
	}

	private int GetTorsoRaiseAnim(PlayerEntity player, WeaponEntity weapon, bool changeClip)
	{
		if (changeClip)
		{
			if (!GetLongClipMod(weapon))
			{
				return 37;
			}
			return 36;
		}
		if (!GetLongClipMod(weapon))
		{
			return 16;
		}
		return 47;
	}

	public static bool GetLongClipMod(WeaponEntity currentWeapon)
	{
		return currentWeapon.special.EffectLevel == 2;
	}

	protected override float GetNextWeaponRaisedSpeed(PlayerEntity player, WeaponEntity currentWeaponEntity, WeaponEntity nextWeaponEntity)
	{
		if (nextWeaponEntity != null && nextWeaponEntity.hasBasicInfo && (nextWeaponEntity.basicInfo.Info.WeaponType == 5 || nextWeaponEntity.basicInfo.Info.WeaponType == 6))
		{
			if (currentWeaponEntity.basicInfo.Info.Name == "glock_redflash1")
			{
				return 1.15f;
			}
			return 1.1f;
		}
		return 1f;
	}
}
