using Assets.Res.Assets.Scripts;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class SkyDomeBeacon : AbstractViewWeaponEffectLogic
{
	private TextureList _textureList;

	private const string WEAPON_EFFECT1 = "qiangshentexiao_Lv0_shouqi";

	private const string WEAPON_EFFECT2 = "qiangshentexiao_Lv0_zhankai";

	private const string WEAPON_EFFECT3 = "qiangshentexiao_Lv1_shouqi";

	private const string WEAPON_EFFECT4 = "qiangshentexiao_Lv1_zhankai";

	private const string WEAPON_EFFECT5 = "qiangshentexiao_Lv2_shouqi";

	private const string WEAPON_EFFECT6 = "qiangshentexiao_Lv2_zhankai";

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		if (currentWeapon.hasBasicInfo)
		{
			bool flag = !player.viewAnim.Equals(15) && !player.viewAnim.Equals(18) && !player.viewAnim.Equals(16);
			bool flag2 = IsZhankai(player, currentWeapon);
			if (currentWeapon.basicInfo.Info.Name == "sky_dome_beacon")
			{
				SetParticleActiveParticleName(player, "qiangshentexiao_Lv0_shouqi", flag);
				SetParticleActiveParticleName(player, "qiangshentexiao_Lv0_zhankai", flag2);
			}
			else if (currentWeapon.basicInfo.Info.Name == "sky_dome_beacon1")
			{
				SetParticleActiveParticleName(player, "qiangshentexiao_Lv1_shouqi", flag);
				SetParticleActiveParticleName(player, "qiangshentexiao_Lv1_zhankai", flag2);
			}
			else if (currentWeapon.basicInfo.Info.Name == "sky_dome_beacon2")
			{
				SetParticleActiveParticleName(player, "qiangshentexiao_Lv2_shouqi", flag);
				SetParticleActiveParticleName(player, "qiangshentexiao_Lv2_zhankai", flag2);
			}
		}
	}

	private bool IsZhankai(PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (player.viewAnim.Equals(15) && player.viewAnim.RightCurrentTime > 550 && player.viewAnim.RightCurrentTime < 1100)
		{
			return true;
		}
		return false;
	}
}
