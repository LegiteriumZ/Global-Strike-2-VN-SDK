using weapon.predicateSystem.implementSeparately;

namespace Assets.Sources.Modules.Player.Attack.SharePredicationApapter;

public class ServerPredicableCallback : IServerPredicableCallback, IPredicableCallBack
{
	public static IServerPredicableCallback Instance = new ServerPredicableCallback();

	public void BeforeFireBullet()
	{
	}

	public void BeforeFireBullet(ICommonWeaponArgs args)
	{
	}

	public void BeforeSecondaryFireBullet(ICommonWeaponArgs args)
	{
	}

	public void AfterFireBullet(ICommonWeaponArgs args)
	{
	}

	public void AfterSecondaryFireBullet(ICommonWeaponArgs args)
	{
	}

	public void AfterLeftSetAttackAnim(ICommonWeaponArgs args)
	{
	}

	public void AfterRightSetAttackAnim(ICommonWeaponArgs args)
	{
	}

	public void AfterLeftSetAttackAnim()
	{
	}

	public void AfterRightSetAttackAnim()
	{
	}

	public void AfterSetAttackTimer()
	{
	}

	public void AfterStartMeleeAttack()
	{
	}

	public void AfterFire(ICommonWeaponArgs args)
	{
	}

	public void AfterSecondaryFire(ICommonWeaponArgs args)
	{
	}

	public void AfterServerFrame(ICommonWeaponArgs args)
	{
	}

	public void ServerFireRecord(ICommonWeaponArgs args)
	{
	}

	public void RightFireFailed(ICommonWeaponArgs args)
	{
	}

	public float GetViewRaiseSpeed()
	{
		return 1f;
	}

	public void SetDamage(float damage)
	{
	}

	public void AfterServerFireBullets(ICommonWeaponArgs args)
	{
	}

	public void AfterWeaponRaised(ICommonWeaponArgs args)
	{
	}

	public void AfterShowGun(ICommonWeaponArgs args)
	{
	}

	public void AfterWeaponStartReload1(ICommonWeaponArgs args)
	{
	}

	public void AfterWeaponStartReload2(ICommonWeaponArgs args)
	{
	}

	public void WhenFireFailed(ICommonWeaponArgs args)
	{
	}

	public void WhenFireSuccess(ICommonWeaponArgs args)
	{
	}

	public void AfterSubtractCarryClip(ICommonWeaponArgs args)
	{
	}

	public void AfterSubtractCarryClip2(ICommonWeaponArgs args)
	{
	}
}
