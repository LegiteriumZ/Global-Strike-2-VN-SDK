using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;
using Sources.Modules.Player.Chain;

namespace Assets.Sources.Modules.Player.Attack.Action;

public class AbstractFireAction : IIdleCmdAction, ICmdAction
{
	protected readonly Contexts Contexts;

	protected WeaponChain<CommonWeaponArg> OnFireFunc;

	protected readonly GunFireCell GunFireCell;

	public AbstractFireAction(Contexts contexts)
	{
		Contexts = contexts;
		GunFireCell = new GunFireCell(contexts);
		OnFireFunc = new WeaponChain<CommonWeaponArg>(2);
	}

	public virtual bool Action(ref CommonWeaponArg arg)
	{
		if (CanFire(ref arg))
		{
			OnFireFunc.Step(ref arg);
		}
		return true;
	}

	protected void AddAction(HitPlayerAction trueChain)
	{
		GunFireCell.AddAction(trueChain);
	}

	protected void AddAction(HitWorldAction trueChain)
	{
		GunFireCell.AddAction(trueChain);
	}

	protected void AddFire(FireUtility.FireFunc trueChain)
	{
		OnFireFunc.AddChain((WeaponFireChain)trueChain);
	}

	protected virtual bool CanFire(ref CommonWeaponArg arg)
	{
		return WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime);
	}

	protected virtual int OnFire(ref CommonWeaponArg arg)
	{
		float shotDistance = arg.CurrentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false);
		if (!arg.Cmd.PredicatedOnce)
		{
			GunFire(ref arg, arg.Cmd.Seq, shotDistance);
		}
		return 0;
	}

	internal void GunFire(ref CommonWeaponArg arg, int seq, float distance)
	{
		if ((arg.Cmd.Buttons | 0x40) > 0)
		{
			distance += Contexts.battleRoom.playerInfo.MyPlayerSkillAdditionalData.LeftAttackExtraDis;
		}
		else if ((arg.Cmd.Buttons | 0x200) > 0)
		{
			distance += Contexts.battleRoom.playerInfo.MyPlayerSkillAdditionalData.RightAttackExtraDis;
		}
		GunFireCell.GunFire(ref arg, seq, distance);
	}

	protected void Reset()
	{
		OnFireFunc.Reset();
	}
}
