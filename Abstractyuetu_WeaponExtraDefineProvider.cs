public abstract class Abstractyuetu_WeaponExtraDefineProvider : AbstractWeaponExtraDefineProvider
{
	public override void Init(Contexts contexts)
	{
		base.Init(contexts);
		_keyInfo = "yuetu";
	}

	public abstract float updateCountProgress();

	public abstract float updateTimeProgress();

	public abstract string updateTxtCount();
}
