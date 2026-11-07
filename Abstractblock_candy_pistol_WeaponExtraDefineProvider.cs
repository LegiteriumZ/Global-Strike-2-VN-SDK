public abstract class Abstractblock_candy_pistol_WeaponExtraDefineProvider : AbstractWeaponExtraDefineProvider
{
	public override void Init(Contexts contexts)
	{
		base.Init(contexts);
		_keyInfo = "block_candy_pistol";
	}

	public abstract float ShowTestBlock();
}
