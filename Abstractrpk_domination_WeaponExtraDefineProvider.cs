public abstract class Abstractrpk_domination_WeaponExtraDefineProvider : AbstractWeaponExtraDefineProvider
{
	public override void Init(Contexts contexts)
	{
		base.Init(contexts);
		_keyInfo = "rpk_domination";
	}

	public abstract string updateSkillENum();

	public abstract string updateLeft0Num();

	public abstract string updateLeft1Num();

	public abstract string updateRight0Num();

	public abstract string updateRight1Num();
}
