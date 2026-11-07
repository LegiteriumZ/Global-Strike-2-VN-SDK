using Assets.Sources.Info.Weapon;
using SSJJPhysics;

namespace SSJJPhysicsExtensions;

public class RootMotionAnimationAdapter : BaseRootMotionAnimationAdapter
{
	public RootMotionAnimationAdapter(PlayerEntity player)
		: base(player)
	{
	}

	protected override string getAnimationResWeaponName(string weaponName)
	{
		return WeaponInfoFactory.Instance.GetWeaponInfo(weaponName).LegsThirdAnimationType;
	}
}
