using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class FrozenAir : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		if (string.IsNullOrEmpty(player.currentWeapon.SkinName))
		{
			if (player.GetCurrentWeaponEffectLevel() > 0)
			{
				WeaponUtility.Fire(player.thirdPersonUnityObjects.RightFires, special: false);
			}
			if (Func == null)
			{
				Func = GetEffect1Flag;
			}
			SetParticleActiveBySkinName(player, Func);
		}
	}

	private static int GetEffect1Flag(PlayerEntity player, string skin, string particle)
	{
		if (particle.Contains("qiangshen"))
		{
			if (PlayerAnimationUtility.IsTorseAnimEqual(player, 17))
			{
				return 0;
			}
			return 1;
		}
		return -1;
	}
}
