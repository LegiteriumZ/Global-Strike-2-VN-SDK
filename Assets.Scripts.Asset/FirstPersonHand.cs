using Assets.Sources.Utils.Weapon;

namespace Assets.Scripts.Asset;

public class FirstPersonHand : FirstPersonWeapon
{
	public override void OnRecycle()
	{
		base.OnRecycle();
		WeaponUtility.SetHandBoneScale(Animator, 1f);
	}
}
