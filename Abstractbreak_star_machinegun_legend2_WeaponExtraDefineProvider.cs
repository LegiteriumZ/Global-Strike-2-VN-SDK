public abstract class Abstractbreak_star_machinegun_legend2_WeaponExtraDefineProvider : AbstractWeaponExtraDefineProvider
{
	public override void Init(Contexts contexts)
	{
		base.Init(contexts);
		_keyInfo = "break_star_machinegun_legend2";
	}

	public abstract string showImage();

	public abstract bool isShow();
}
