using Assets.Res.Assets.Scripts;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class SkyDomeBeacon : AbstractThirdWeaponEffectLogic
{
	private TextureList _textureList;

	private const string WEAPON_EFFECT1 = "qiangshentexiao_Lv0_zhankai";

	private const string WEAPON_EFFECT2 = "qiangshentexiao_Lv1_zhankai";

	private const string WEAPON_EFFECT3 = "qiangshentexiao_Lv2_zhankai";

	public override void Update(PlayerEntity player, int raceType)
	{
		if (player.GetCurrentWeaponName() == "sky_dome_beacon")
		{
			SetParticleActiveParticleName(player, "qiangshentexiao_Lv0_zhankai", flag: false);
		}
		else if (player.GetCurrentWeaponName() == "sky_dome_beacon1")
		{
			SetParticleActiveParticleName(player, "qiangshentexiao_Lv1_zhankai", flag: false);
		}
		else if (player.GetCurrentWeaponName() == "sky_dome_beacon2")
		{
			SetParticleActiveParticleName(player, "qiangshentexiao_Lv2_zhankai", flag: false);
		}
	}
}
