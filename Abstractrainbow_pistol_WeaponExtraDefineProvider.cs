public abstract class Abstractrainbow_pistol_WeaponExtraDefineProvider : AbstractWeaponExtraDefineProvider
{
	public override void Init(Contexts contexts)
	{
		base.Init(contexts);
		_keyInfo = "rainbow_pistol";
	}

	public abstract string updateAutoHitUrl();
}
