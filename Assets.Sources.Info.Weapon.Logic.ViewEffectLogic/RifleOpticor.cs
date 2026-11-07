using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class RifleOpticor : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		if (Func == null)
		{
			Func = SetEffectFlag;
		}
		SetParticleActiveBySkinName(player, currentWeapon, Func);
	}

	private int SetEffectFlag(PlayerEntity player, WeaponEntity currentWeapon, string skin, string particle)
	{
		bool num = player.viewAnim.ViewAnimInfo.StateId == 36 || player.viewAnim.ViewAnimInfo.StateId == 37;
		int currentWeaponEffectLevel = player.GetCurrentWeaponEffectLevel();
		if (num)
		{
			return 0;
		}
		if ((particle.Equals("1_shengpan_jian") || particle.Equals("ciyuanhuanying_jian")) && skin.Equals("weapon_particle_effect1"))
		{
			if ((currentWeaponEffectLevel & 1) > 0)
			{
				return 1;
			}
		}
		else if ((particle.Equals("1_shengpan_qiang") || particle.Equals("ciyuanhuanying_qiangshen")) && skin.Equals("weapon_particle_effect1"))
		{
			if ((currentWeaponEffectLevel & 1) == 0)
			{
				return 1;
			}
		}
		else if (particle.Equals("2_qiangkouhuohua") && FireUtility.IsFiring(player, isSelf: true, right: true, viewCheckLeftAttackFire: true))
		{
			return 1;
		}
		return 0;
	}
}
