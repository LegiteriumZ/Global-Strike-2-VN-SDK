public abstract class Abstractgaia_sniper_WeaponExtraDefineProvider : AbstractWeaponExtraDefineProvider
{
	public override void Init(Contexts contexts)
	{
		base.Init(contexts);
		_keyInfo = "gaia_sniper";
	}

	public abstract bool updateSkillEShow();
}
