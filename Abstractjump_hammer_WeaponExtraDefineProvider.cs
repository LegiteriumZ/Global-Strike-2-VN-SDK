public abstract class Abstractjump_hammer_WeaponExtraDefineProvider : AbstractWeaponExtraDefineProvider
{
	public override void Init(Contexts contexts)
	{
		base.Init(contexts);
		_keyInfo = "jump_hammer";
	}

	public abstract bool isShow();

	public abstract string showImage();
}
