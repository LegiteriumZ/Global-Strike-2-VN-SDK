using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.AnimState;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Components.Player;
using Assets.Sources.Components.Player.Anims;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Player.Anim.ThirdPerson.Utility;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson;

public class PlayerLegPredictionSystem : IPredicateSystem
{
	private readonly List<string> _duckPredicateCareer = new List<string> { "p3hero" };

	public void OnPredicate(PlayerEntity myPlayer, IUserCmd cmd)
	{
		LegAnimComponent legAnim = myPlayer.legAnim;
		BasicInfoComponent basicInfo = myPlayer.basicInfo;
		DuckPredicate(myPlayer, cmd);
		legAnim.RemainTime -= cmd.FrameInterval;
		float num = 1f;
		if (legAnim.LegsAnimInfo != null)
		{
			num = legAnim.LegsAnimInfo.GetAnimSpeed(myPlayer.move.Velocity2D);
		}
		legAnim.ScaledEclipsedTime += (int)((float)cmd.FrameInterval * num);
		if (legAnim.RemainTime < 0)
		{
			legAnim.RemainTime = 0;
		}
		if (legAnim.RemainTime <= 0 && myPlayer.hasCurrentWeapon && legAnim.LegsAnimInfo != null)
		{
			IEntitsWeaponInfo weaponInfo = myPlayer.currentWeapon.WeaponInfo;
			if (weaponInfo != null)
			{
				ILegAnimStateInfo nextState = legAnim.LegsAnimInfo.GetNextState(weaponInfo, basicInfo.CareerInfo, legAnim.LegsAnimInfo.StateId);
				LegPredictionUtility.CommonResetLegInfo(legAnim, nextState, basicInfo.CareerInfo, weaponInfo);
			}
		}
	}

	public void DuckPredicate(PlayerEntity myPlayer, IUserCmd cmd)
	{
		string name = myPlayer.basicInfo.CareerInfo.Name;
		bool flag = false;
		foreach (string item in _duckPredicateCareer)
		{
			if (item.Equals(name))
			{
				flag = true;
			}
		}
		LegAnimComponent legAnim = myPlayer.legAnim;
		ILegAnimStateInfo legsAnimInfo = legAnim.LegsAnimInfo;
		if (legsAnimInfo != null && flag)
		{
			LegPredictionUtility.DuckPredication(myPlayer, legsAnimInfo, legAnim);
		}
	}
}
