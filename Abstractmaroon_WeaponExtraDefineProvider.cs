public abstract class Abstractmaroon_WeaponExtraDefineProvider : AbstractWeaponExtraDefineProvider
{
	public override void Init(Contexts contexts)
	{
		base.Init(contexts);
		_keyInfo = "maroon";
	}

	public abstract bool updateImgVisible();

	public abstract string updateFlashImg();
}
