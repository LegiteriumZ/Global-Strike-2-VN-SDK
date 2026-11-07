public abstract class Abstractfeather_bow_WeaponExtraDefineProvider : AbstractWeaponExtraDefineProvider
{
	public override void Init(Contexts contexts)
	{
		base.Init(contexts);
		_keyInfo = "feather_bow";
	}

	public abstract float getProgress();

	public abstract bool isShow();
}
