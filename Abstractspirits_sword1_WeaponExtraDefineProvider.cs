public abstract class Abstractspirits_sword1_WeaponExtraDefineProvider : AbstractWeaponExtraDefineProvider
{
	public override void Init(Contexts contexts)
	{
		base.Init(contexts);
		_keyInfo = "spirits_sword1";
	}

	public abstract bool updateImgVisible();

	public abstract string updateFlashImg();
}
