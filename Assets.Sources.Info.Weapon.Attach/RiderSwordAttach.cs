using Assets.Sources.Components.Weapon;
using Assets.Sources.Utils.PlayerAnim;

namespace Assets.Sources.Info.Weapon.Attach;

internal class RiderSwordAttach : AbstractAttach
{
	public int AddSpeedEndTime;

	public float KnifeSpeed = 1f;

	public void AddKnifeSpeed(PlayerEntity player, WeaponEntity currentWeapon, int anim)
	{
		if (currentWeapon.clip.Clip2 != 0)
		{
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, anim);
			if (player.clientTime.ClientTime <= AddSpeedEndTime)
			{
				KnifeSpeed = Min(0.1f + KnifeSpeed, 1.3f);
			}
			else
			{
				KnifeSpeed = 1f;
			}
			AddSpeedEndTime = player.clientTime.ClientTime + viewAnimDuration + 2000;
			player.viewAnim.RightSpeed = KnifeSpeed;
			int num = (int)((float)player.clientTime.ClientTime + (float)viewAnimDuration / KnifeSpeed);
			currentWeapon.attack.NextSecondaryAttackTimer = num;
		}
	}

	private float Min(float a, float b)
	{
		if (a <= b)
		{
			return a;
		}
		return b;
	}
}
