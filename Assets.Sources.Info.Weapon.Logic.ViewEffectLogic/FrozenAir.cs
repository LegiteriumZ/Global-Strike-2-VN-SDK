using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class FrozenAir : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		if (string.IsNullOrEmpty(player.currentWeapon.SkinName))
		{
			if (player.GetCurrentWeaponEffectLevel() > 0)
			{
				WeaponUtility.Fire(player.firstPersonUnityObjects.RightFires, special: false);
			}
			if (Func == null)
			{
				Func = GetEffect1Flag;
			}
			SetParticleActiveBySkinName(player, currentWeapon, Func);
		}
	}

	private static int GetEffect1Flag(PlayerEntity player, WeaponEntity currentWeapon, string skin, string particle)
	{
		if (particle.Contains("qiangshen"))
		{
			if (PlayerAnimationUtility.IsViewAnimEqual(player, 17))
			{
				return 0;
			}
			return 1;
		}
		return -1;
	}
}
