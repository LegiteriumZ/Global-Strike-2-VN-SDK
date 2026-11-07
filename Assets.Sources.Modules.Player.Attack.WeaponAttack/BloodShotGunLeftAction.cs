using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using math;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BloodShotGunLeftAction : ShotGuntLeftAction
{
	private readonly int[] _animIds = new int[3] { 15, 29, 32 };

	public BloodShotGunLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddFire(BloodShotGunSetFireAnim);
	}

	private int BloodShotGunSetFireAnim(ref CommonWeaponArg arg)
	{
		int num = UniformRandom.RandomInt(arg.ClientTime, 0, 2);
		PlayerAnimationUtility.SetViewAnimation(arg.Player, _animIds[num]);
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return 0;
	}
}
