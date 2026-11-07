public abstract class Abstractinflatable_hammer_WeaponExtraDefineProvider : AbstractWeaponExtraDefineProvider
{
	public override void Init(Contexts contexts)
	{
		base.Init(contexts);
		_keyInfo = "inflatable_hammer";
	}

	public abstract float getInflatableHammerScale();
}
