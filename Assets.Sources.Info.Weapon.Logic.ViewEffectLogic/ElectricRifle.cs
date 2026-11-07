namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class ElectricRifle : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		bool flag = currentWeapon.basicInfo.Data.Level == 1;
		bool flag2 = currentWeapon.basicInfo.Data.Level == 2;
		SetParticleActiveParticleName(player, "gatherpower", flag);
		SetParticleActiveParticleName(player, "fullpower", flag2);
		if (flag)
		{
			GetFireControlByParticleName(player, "gatherpower").enabled = true;
			SetParticleNoFireControlByParticleName(player, "gatherpower");
		}
		if (flag2)
		{
			GetFireControlByParticleName(player, "fullpower").enabled = true;
			SetParticleNoFireControlByParticleName(player, "fullpower");
		}
	}
}
