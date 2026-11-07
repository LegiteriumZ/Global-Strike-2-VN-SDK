using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Modules.Player.Chain;
using Assets.Sources.Utils.Weapon;
using Sources.Modules.Player.Chain;

namespace Assets.Sources.Modules.Player.Attack.Action;

public abstract class AbstractFrameAction : IFrameCmdAction, ICmdAction
{
	protected internal WeaponChain<CommonWeaponArg> FrameChain;

	protected internal IIdleCmdAction BindAction;

	protected internal Contexts GameContexts;

	public AbstractFrameAction(Contexts contexts)
	{
		GameContexts = contexts;
		FrameChain = new WeaponChain<CommonWeaponArg>(2);
		AddFrameAction(Zoom);
		AddFrameAction(Frame);
	}

	public AbstractFrameAction(Contexts contexts, IIdleCmdAction action)
		: this(contexts)
	{
		Bind(action);
	}

	public void Bind(IIdleCmdAction action)
	{
		BindAction = action;
	}

	public void AddFrameAction(WeaponFrameAction callback)
	{
		FrameChain.AddChain((WeaponFrameChain)callback);
	}

	public virtual bool Action(ref CommonWeaponArg arg)
	{
		FrameChain.Step(ref arg);
		return true;
	}

	protected virtual bool IsPistol()
	{
		return false;
	}

	protected virtual int Frame(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.IsSecondaryAttackOn)
		{
			if (!arg.Cmd.IsAttackOn && IsPistol())
			{
				arg.CurrentWeapon.attack.ShotsFired = 0;
			}
		}
		else if (!arg.Cmd.IsAttackOn)
		{
			if (arg.CurrentWeapon.attack.DelayFire)
			{
				arg.CurrentWeapon.attack.DelayFire = false;
				if (arg.Player.move.RunUpMax)
				{
					arg.Player.move.RunUpMax = false;
				}
				if (arg.CurrentWeapon.attack.ShotsFired > 8)
				{
					arg.CurrentWeapon.attack.ShotsFired = 8;
				}
				arg.CurrentWeapon.attack.DecreaseShotsFired = arg.ClientTime + 150;
			}
			if (IsPistol())
			{
				arg.CurrentWeapon.attack.ShotsFired = 0;
			}
			else if (arg.CurrentWeapon.attack.ShotsFired > 0 && arg.CurrentWeapon.attack.DecreaseShotsFired < arg.ClientTime)
			{
				arg.CurrentWeapon.attack.DecreaseShotsFired = arg.ClientTime + 16;
				arg.CurrentWeapon.attack.ShotsFired--;
			}
			else if (arg.CurrentWeapon.attack.ShotsFired == 0)
			{
				WeaponUtility.Depoly(arg.CurrentWeapon);
			}
		}
		return 0;
	}

	protected int Zoom(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.attack.NextAttackTimer <= (float)arg.ClientTime && arg.Player.fov.ResumeZoom)
		{
			arg.Player.fov.Fov = arg.Player.fov.LastFov;
			arg.Player.fov.DelayFov = arg.Player.fov.LastFov;
			arg.Player.fov.ResumeZoom = false;
		}
		return 0;
	}
}
