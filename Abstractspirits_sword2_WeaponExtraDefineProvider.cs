public abstract class Abstractspirits_sword2_WeaponExtraDefineProvider : AbstractWeaponExtraDefineProvider
{
	public override void Init(Contexts contexts)
	{
		base.Init(contexts);
		_keyInfo = "spirits_sword2";
	}

	public abstract bool updateImgVisible();

	public abstract string updateFlashImg();
}
