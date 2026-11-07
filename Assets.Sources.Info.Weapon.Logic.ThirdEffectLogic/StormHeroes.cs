namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class StormHeroes : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		GetSkins(player)["weaponeffect"].gameObject.SetObjectActive(player.GetCurrentWeaponLevel() != 0);
	}
}
