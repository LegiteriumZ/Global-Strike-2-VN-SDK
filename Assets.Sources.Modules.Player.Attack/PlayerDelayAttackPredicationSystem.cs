using System.Collections.Generic;
using Assets.Sources.Framework;
using SSJJBase.Logger;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack;

public class PlayerDelayAttackPredicationSystem : IPredicateSystem
{
	private readonly WeaponContext _weaponContext;

	private int _lasttime = -1;

	public PlayerDelayAttackPredicationSystem(Contexts contexts)
	{
		_weaponContext = contexts.weapon;
	}

	public void OnPredicate(PlayerEntity myPlayer, IUserCmd cmd)
	{
		if (_lasttime == myPlayer.clientTime.ClientTime)
		{
			return;
		}
		_lasttime = myPlayer.clientTime.ClientTime;
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null || !currentWeaponEntity.hasDelayAttack || (currentWeaponEntity.delayAttack.DelayFireRemain <= 0 && !currentWeaponEntity.delayAttack.IsDelayAttackImmdiately))
		{
			return;
		}
		if (myPlayer.viewAnim.ViewAnimInfo == null)
		{
			this.LogErrorFormat("{0} view anim is Null but has delay attack", myPlayer);
			currentWeaponEntity.RemoveDelayAttack();
		}
		else if (currentWeaponEntity.basicInfo.Info == null)
		{
			this.LogErrorFormat("{0} weaponinfo is Null but has delay attack", myPlayer);
			currentWeaponEntity.RemoveDelayAttack();
		}
		else
		{
			if (cmd.Seq <= currentWeaponEntity.delayAttack.Seq)
			{
				return;
			}
			Dictionary<int, IUserCmd> cmds = currentWeaponEntity.delayAttack.Cmds;
			if (cmds.ContainsKey(cmd.Seq))
			{
				return;
			}
			cmds.Add(cmd.Seq, cmd);
			int num = cmd.Seq - 1;
			IUserCmd value = null;
			if (cmds.TryGetValue(num, out value))
			{
				currentWeaponEntity.delayAttack.DelayFireRemain -= value.FrameInterval;
			}
			else if (num == currentWeaponEntity.delayAttack.Seq)
			{
				currentWeaponEntity.delayAttack.DelayFireRemain -= currentWeaponEntity.delayAttack.CurrentFrameInterval;
			}
			if (currentWeaponEntity.delayAttack.DelayFireRemain <= 0)
			{
				if (currentWeaponEntity.delayAttack.CallBack != null)
				{
					currentWeaponEntity.delayAttack.CallBack(currentWeaponEntity.delayAttack, cmd);
				}
				currentWeaponEntity.RemoveDelayAttack();
			}
		}
	}
}
