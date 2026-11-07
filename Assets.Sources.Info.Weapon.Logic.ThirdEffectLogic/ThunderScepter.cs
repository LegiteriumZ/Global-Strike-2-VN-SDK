using Assets.Sources.Constant;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class ThunderScepter : AbstractThirdWeaponEffectLogic
{
	private const string WeaponEffect1 = "qiangkouhuohua";

	private const string WeaponEffect2 = "qkhh";

	private const string WeaponEffect3 = "chongneng";

	public override void Update(PlayerEntity player, int raceType)
	{
		if (string.IsNullOrEmpty(player.currentWeapon.SkinName))
		{
			bool flag = player.hasTorseAnim && player.torseAnim.TorsoAnimInfo != null && player.torseAnim.TorsoAnimInfo.StateId == 17;
			SetParticleActiveParticleName(player, "chongneng", flag);
			bool flag2 = RuleUtilty.IsPve(raceType) || RuleUtilty.IsBioMode(raceType) || RuleUtilty.IsBigHeadModel(raceType);
			SetParticleActiveParticleName(player, "qkhh", flag2);
			SetParticleActiveParticleName(player, "qiangkouhuohua", !flag2);
		}
	}
}
