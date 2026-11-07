public abstract class Abstractbreak_star_machinegun_legend1_WeaponExtraDefineProvider : AbstractWeaponExtraDefineProvider
{
	public override void Init(Contexts contexts)
	{
		base.Init(contexts);
		_keyInfo = "break_star_machinegun_legend1";
	}

	public abstract bool isShow();

	public abstract string showImage();
}
