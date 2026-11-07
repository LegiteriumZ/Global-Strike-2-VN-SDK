using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.AnimData;
using Assets.Sources.Components.Interface.Info.AnimState;
using Assets.Sources.Components.Player.Anims;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Framework.System;
using Assets.Sources.Utils.PlayerAnim;
using Entitas;
using SSJJAnim.AnimData;
using SSJJAnim.CareerAnim;
using SSJJBase.Manager;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson;

public class PlayerLegWrapAnimPlaybackSystem : FrameExecuteSystem, IPlaybackSystem
{
	private IGroup<PlayerEntity> _players;

	private TimeComponent _timeComponent;

	private readonly Dictionary<string, float> _keyData = new Dictionary<string, float>();

	private const string CommonWeaponName = "common";

	private Dictionary<int, float> preVelocity2DList = new Dictionary<int, float>();

	public PlayerLegWrapAnimPlaybackSystem(Contexts contexts)
	{
		_players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.LegAnim).NoneOf(PlayerMatcher.Prediction));
		_timeComponent = contexts.time.time;
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity player in _players)
		{
			int torsoAnimId = PlayerAnimationUtility.GetTorsoAnimId(player);
			int legAnimId = PlayerAnimationUtility.GetLegAnimId(player);
			if (PlayerAnimationUtility.CheckIsWarpAnimSystem(player, legAnimId, torsoAnimId))
			{
				player.legAnim.WrapCurrentTime = (float)player.basicInfo.Current.LegsAnimProcess * 1E-06f;
				player.legAnim.WrapPassTime = (float)(_timeComponent.RenderTime - player.basicInfo.SnapsotServerTime) * 0.001f;
				UpdatePlayerWarpAni(player);
			}
		}
	}

	private void UpdatePlayerWarpAni(PlayerEntity entity)
	{
		LegAnimComponent legAnim = entity.legAnim;
		ILegAnimStateInfo legsAnimInfo = legAnim.LegsAnimInfo;
		ICareerAnimInfo careerAnimInfo = BattleSingletonInstance<CareerAnimInfoFactory>.Instance.GetCareerAnimInfo(entity.basicInfo.CareerInfo);
		AnimationWarpsData wrapAnimation = careerAnimInfo.GetWrapAnimation(entity.currentWeapon.WeaponInfo.Name, legsAnimInfo.StateId);
		ISjAnimatior animator = entity.thirdPersonUnityObjects.Animator;
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
		if (legAnimationWrapUnit == null)
		{
			return;
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
		float value = 0f;
		float value2 = Mathf.Min((float)entity.basicInfo.Current.Velocity2D / 650f, 1f);
		if (preVelocity2DList.ContainsKey(entity.GetId()))
		{
			value = preVelocity2DList[entity.GetId()];
		}
		_keyData.Add("subYaw", (float)num);
		_keyData.Add("runSpeed", Mathf.Max((float)entity.basicInfo.Current.Velocity2D / 650f, 1f));
		_keyData.Add("preVelocity2D", value);
		_keyData.Add("velocity2D", value2);
		float animationSpeed = legAnimationWrapUnit.GetAnimationSpeed(_keyData);
		bool isLoop = legAnimationWrapUnit.IsLoop;
		float totalTime = legAnimationWrapUnit.GetTotalTime(0, _keyData, animator);
		legAnim.IsWarpLoop = isLoop;
		if (!Mathf.Approximately(totalTime, 0f))
		{
			legAnimationWrapUnit.GetAnimation(0, _keyData, legAnim.WrapStateDatas, animator, legAnim.WrapCurrentTime);
			legAnim.WrapCurrentTime = legAnim.WrapCurrentTime * totalTime + entity.legAnim.WrapPassTime * animationSpeed;
			if (legAnim.WrapCurrentTime >= totalTime)
			{
				preVelocity2DList[entity.GetId()] = value2;
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
