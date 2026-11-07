public abstract class Abstractcarrot_one_WeaponExtraDefineProvider : AbstractWeaponExtraDefineProvider
{
	public override void Init(Contexts contexts)
	{
		base.Init(contexts);
		_keyInfo = "carrot_one";
	}

	public abstract float getProgress();

	public abstract float getProgress1();

	public abstract string showImage();
}
