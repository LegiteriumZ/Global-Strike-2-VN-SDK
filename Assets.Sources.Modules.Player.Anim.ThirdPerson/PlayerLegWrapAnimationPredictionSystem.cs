using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.AnimData;
using Assets.Sources.Components.Interface.Info.AnimState;
using Assets.Sources.Components.Player.Anims;
using Assets.Sources.Framework;
using Assets.Sources.Utils.PlayerAnim;
using SSJJAnim.AnimData;
using SSJJAnim.CareerAnim;
using SSJJBase.Manager;
using SSJJMath;
using SSJJUserCmd;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson;

public class PlayerLegWrapAnimationPredictionSystem : IPredicateSystem
{
	private readonly Dictionary<string, float> _keyData = new Dictionary<string, float>();

	private const string CommonWeaponName = "common";

	private float preVelocity2D;

	private readonly Dictionary<string, float> _preVec = new Dictionary<string, float>();

	public void OnPredicate(PlayerEntity entity, IUserCmd cmd)
	{
		int torsoAnimId = PlayerAnimationUtility.GetTorsoAnimId(entity);
		int legAnimId = PlayerAnimationUtility.GetLegAnimId(entity);
		if (!PlayerAnimationUtility.CheckIsWarpAnimSystem(entity, legAnimId, torsoAnimId))
		{
			return;
		}
		LegAnimComponent legAnim = entity.legAnim;
		ILegAnimStateInfo legsAnimInfo = legAnim.LegsAnimInfo;
		ICareerAnimInfo careerAnimInfo = BattleSingletonInstance<CareerAnimInfoFactory>.Instance.GetCareerAnimInfo(entity.basicInfo.CareerInfo);
		AnimationWarpsData wrapAnimation = careerAnimInfo.GetWrapAnimation(entity.currentWeapon.WeaponInfo.Name, legsAnimInfo.StateId);
		LegAnimationWrapUnit legAnimationWrapUnit = null;
		if (wrapAnimation == null)
		{
			wrapAnimation = careerAnimInfo.GetWrapAnimation("common", legsAnimInfo.StateId);
			if (wrapAnimation != null)
			{
				legAnimationWrapUnit = wrapAnimation.GetLegWrapUnit(legsAnimInfo.StateId);
			}
		}
		else
		{
			legAnimationWrapUnit = wrapAnimation.GetLegWrapUnit(legsAnimInfo.StateId);
		}
		ISjAnimatior animator = entity.thirdPersonUnityObjects.Animator;
		if (legAnimationWrapUnit == null)
		{
			wrapAnimation = careerAnimInfo.GetWrapAnimation("common", legsAnimInfo.StateId);
			if (wrapAnimation != null)
			{
				legAnimationWrapUnit = wrapAnimation.GetLegWrapUnit(legsAnimInfo.StateId);
			}
		}
		if (legAnimationWrapUnit == null)
		{
			return;
		}
		if (legAnim.WarpCurrent == null)
		{
			legAnim.WarpCurrent = legAnimationWrapUnit;
			legAnim.WrapCurrentTime = 0f;
		}
		else if (legAnim.WarpCurrent != legAnimationWrapUnit)
		{
			legAnim.WarpCurrent = legAnimationWrapUnit;
			legAnim.WrapCurrentTime = 0f;
		}
		double num = AngleUtility.MakeAngleInRange(entity.GetMoveYaw() - (double)entity.GetViewYaw());
		if (!entity.move.Moving)
		{
			num = 0.0;
		}
		_keyData.Clear();
		if (legAnim.WrapStateDatas == null)
		{
			legAnim.WrapStateDatas = new List<IAnimationWarpsStateData>();
		}
		foreach (IAnimationWarpsStateData wrapStateData in legAnim.WrapStateDatas)
		{
			AnimationWrapStateDataUtility.Collect(wrapStateData);
		}
		legAnim.WrapStateDatas.Clear();
		float value = Mathf.Min((float)entity.move.Velocity2D / 650f, 1f);
		_keyData.Add("subYaw", (float)num);
		_keyData.Add("runSpeed", Mathf.Max((float)entity.move.Velocity2D / 650f, 1f));
		_keyData.Add("preVelocity2D", preVelocity2D);
		_keyData.Add("velocity2D", value);
		float animationSpeed = legAnimationWrapUnit.GetAnimationSpeed(_keyData);
		bool isLoop = legAnimationWrapUnit.IsLoop;
		float totalTime = legAnimationWrapUnit.GetTotalTime(0, _keyData, animator);
		legAnim.IsWarpLoop = isLoop;
		if (!Mathf.Approximately(totalTime, 0f))
		{
			legAnimationWrapUnit.GetAnimation(0, _keyData, legAnim.WrapStateDatas, animator, legAnim.WrapCurrentTime);
			legAnim.WrapCurrentTime = legAnim.WrapCurrentTime * totalTime + (float)cmd.FrameInterval * 0.001f * animationSpeed;
			if (legAnim.WrapCurrentTime >= totalTime)
			{
				preVelocity2D = value;
			}
			legAnim.WrapCurrentTime /= totalTime;
			if (!isLoop && legAnim.WrapCurrentTime > 1f)
			{
				legAnim.WrapCurrentTime = 1f;
			}
			else
			{
				legAnim.WrapCurrentTime -= (int)legAnim.WrapCurrentTime;
			}
		}
	}
}
