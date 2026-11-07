using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class ArcElectricShotgunReloadPredicationSystem : AbstractReloadPrediactionSystem
{
	private readonly WeaponContext _weaponContext;

	private const int maxPowerClip = 50;

	public ArcElectricShotgunReloadPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		_weaponContext = contexts.weapon;
	}

	protected override void PredictCmdOnWeapon(PlayerEntity player, IUserCmd cmd)
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null)
		{
			return;
		}
		_ = currentWeaponEntity.special.SpecialMode;
		if (cmd.IsReloadOn && CanReload(currentWeaponEntity) && CanReloadAnim(player))
		{
			SetReloadAnim(player, currentWeaponEntity);
		}
		if (currentWeaponEntity.special.SpecialMode)
		{
			if (CanReloadAnim(player) && !currentWeaponEntity.reload.IsStartReload && currentWeaponEntity.power.Power == 0 && currentWeaponEntity.power.MaxPower > 0)
			{
				SetReloadAnim(player, currentWeaponEntity);
			}
		}
		else if (CanReloadAnim(player) && !currentWeaponEntity.reload.IsStartReload && currentWeaponEntity.clip.Clip == 0 && currentWeaponEntity.clip.CarryClip > 0)
		{
			SetReloadAnim(player, currentWeaponEntity);
		}
		if (currentWeaponEntity.reload.IsStartReload)
		{
			if (WeaponUtility.CanReload(currentWeaponEntity))
			{
				currentWeaponEntity.reload.IsStartReload = false;
				currentWeaponEntity.reload.ReloadEndTime = 0f;
			}
			if (currentWeaponEntity.reload.ReloadEndTime < (float)player.clientTime.ClientTime)
			{
				currentWeaponEntity.reload.IsStartReload = false;
				currentWeaponEntity.reload.ReloadEndTime = 0f;
				ReloadClipRight(currentWeaponEntity);
			}
		}
	}

	private bool CanReload(WeaponEntity weapon)
	{
		if (weapon.special.SpecialMode)
		{
			if (!weapon.reload.IsStartReload && weapon.power.MaxPower > 0)
			{
				return weapon.power.Power < 50;
			}
			return false;
		}
		if (!weapon.reload.IsStartReload && weapon.clip.CarryClip > 0)
		{
			return weapon.clip.Clip < weapon.basicInfo.Info.MaxClip;
		}
		return false;
	}

	private void ReloadClipRight(WeaponEntity currentWeapon)
	{
		if (currentWeapon.special.SpecialMode)
		{
			int power = currentWeapon.power.Power;
			int maxPower = currentWeapon.power.MaxPower;
			int num = 0;
			if (power < 50)
			{
				if (maxPower + power > 50)
				{
					currentWeapon.power.Power = 50;
					num = 50 - power;
				}
				else
				{
					currentWeapon.power.Power = maxPower + power;
					num = maxPower;
				}
			}
			currentWeapon.power.MaxPower -= num;
			return;
		}
		int clip = currentWeapon.clip.Clip;
		int maxClip = currentWeapon.basicInfo.Info.MaxClip;
		int carryClip = currentWeapon.clip.CarryClip;
		int num2 = 0;
		if (clip < maxClip)
		{
			if (carryClip + clip > maxClip)
			{
				currentWeapon.clip.Clip = maxClip;
				num2 = maxClip - clip;
			}
			else
			{
				currentWeapon.clip.Clip = carryClip + clip;
				num2 = carryClip;
			}
		}
		currentWeapon.clip.CarryClip -= num2;
	}
}
