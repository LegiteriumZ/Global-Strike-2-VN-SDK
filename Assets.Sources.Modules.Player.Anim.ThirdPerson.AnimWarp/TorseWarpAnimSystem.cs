using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.AnimData;
using Assets.Sources.Components.Interface.Info.AnimState;
using Assets.Sources.Framework;
using Assets.Sources.Framework.System;
using Assets.Sources.Utils.PlayerAnim;
using Entitas;
using SSJJAnim.AnimData;
using SSJJAnim.CareerAnim;
using SSJJBase.Manager;
using SSJJMath;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson.AnimWarp;

public class TorseWarpAnimSystem : FrameExecuteSystem, IPlaybackSystem
{
	private readonly IGroup<PlayerEntity> _players;

	private readonly Dictionary<string, float> _keyData;

	private List<IAnimationWarpsStateData> _stateDatas;

	private const string CommonWeaponName = "common";

	public TorseWarpAnimSystem(Contexts contexts)
	{
		_players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ThirdPersonUnityObjects, PlayerMatcher.TorseAnim));
		_keyData = new Dictionary<string, float>();
		_stateDatas = new List<IAnimationWarpsStateData>();
	}

	public void OnRender()
	{
		foreach (PlayerEntity player in _players)
		{
			int torsoAnimId = PlayerAnimationUtility.GetTorsoAnimId(player);
			int legAnimId = PlayerAnimationUtility.GetLegAnimId(player);
			if (PlayerAnimationUtility.CheckIsWarpAnimSystem(player, legAnimId, torsoAnimId))
			{
				UpdatePlayerTorsoAnim(player);
			}
		}
	}

	public void OnPlayback()
	{
		OnRender();
	}

	private void UpdatePlayerTorsoAnim(PlayerEntity entity)
	{
		if (!entity.hasThirdPersonUnityObjects)
		{
			return;
		}
		ISjAnimatior animator = entity.thirdPersonUnityObjects.Animator;
		ITorseAnimStateInfo torsoAnimInfo = entity.torseAnim.TorsoAnimInfo;
		if (torsoAnimInfo == null)
		{
			return;
		}
		ICareerAnimInfo careerAnimInfo = BattleSingletonInstance<CareerAnimInfoFactory>.Instance.GetCareerAnimInfo(entity.basicInfo.CareerInfo);
		int eclipsedTime = entity.torseAnim.EclipsedTime;
		AnimationWarpsData wrapAnimation = careerAnimInfo.GetWrapAnimation(entity.currentWeapon.WeaponInfo.Name, torsoAnimInfo.StateId);
		if (wrapAnimation == null)
		{
			animator.StopAll(1);
			return;
		}
		TorsoAnimationWrapUnit torsoWrapUnit = wrapAnimation.GetTorsoWrapUnit(torsoAnimInfo.StateId);
		if (torsoWrapUnit == null)
		{
			wrapAnimation = careerAnimInfo.GetWrapAnimation("common", torsoAnimInfo.StateId);
			if (wrapAnimation != null)
			{
				torsoWrapUnit = wrapAnimation.GetTorsoWrapUnit(torsoAnimInfo.StateId);
			}
		}
		if (torsoWrapUnit == null)
		{
			animator.StopAll(1);
			return;
		}
		float value = AngleUtility.MakeAngleInRange(entity.orientation.Pitch);
		_keyData.Clear();
		foreach (IAnimationWarpsStateData stateData in _stateDatas)
		{
			AnimationWrapStateDataUtility.Collect(stateData);
		}
		_stateDatas.Clear();
		_keyData.Add("pitch", value);
		float animation = torsoWrapUnit.GetAnimation(_keyData, ref _stateDatas, 1, animator);
		bool isVisiable = !entity.hasVisiable || entity.visiable.IsVisiable || entity.visiable.IsNear;
		torsoAnimInfo.IsWarpAnim = true;
		torsoAnimInfo.WrapSpeed = 1f;
		animator.PlayAtFixedTime(1, (float)eclipsedTime / 1000f / animation, _stateDatas, torsoWrapUnit.IsLoop, isVisiable);
	}
}
