using Assets.Sources.Components.Time;

public class inflatable_hammer_WeaponExtraDefineProvider : Abstractinflatable_hammer_WeaponExtraDefineProvider
{
	private WeaponEntity _weapon;

	public override void OnFrame(TimeComponent time)
	{
		_weapon = _weaponContext.currentWeaponEntity;
	}

	public override float getInflatableHammerScale()
	{
		return 1f + (float)_weapon.basicInfo.Data.Power * 0.005f;
	}
}
