using Assets.Sources.Components.Interface.Info.AnimData;
using Assets.Sources.Framework;
using Assets.Sources.Framework.System;
using Assets.Sources.Utils.PlayerAnim;
using Entitas;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson.AnimWarp;

public class LegWarpAnimSystem : FrameExecuteSystem, IPlaybackSystem
{
	private readonly IGroup<PlayerEntity> _players;

	public LegWarpAnimSystem(Contexts contexts)
	{
		_players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ThirdPersonUnityObjects, PlayerMatcher.LegAnim));
	}

	public void OnRender()
	{
		foreach (PlayerEntity player in _players)
		{
			int torsoAnimId = PlayerAnimationUtility.GetTorsoAnimId(player);
			int legAnimId = PlayerAnimationUtility.GetLegAnimId(player);
			if (PlayerAnimationUtility.CheckIsWarpAnimSystem(player, legAnimId, torsoAnimId))
			{
				SetPlayerLegsAnim(player);
			}
		}
	}

	public void OnPlayback()
	{
		OnRender();
	}

	private void SetPlayerLegsAnim(PlayerEntity entity)
	{
		if (entity.hasThirdPersonUnityObjects)
		{
			ISjAnimatior animator = entity.thirdPersonUnityObjects.Animator;
			if (entity.legAnim.LegsAnimInfo != null && entity.legAnim.WrapStateDatas != null)
			{
				bool isVisiable = !entity.hasVisiable || entity.visiable.IsVisiable || entity.visiable.IsNear;
				animator.PlayAtFixedTime(0, entity.legAnim.WrapCurrentTime, entity.legAnim.WrapStateDatas, entity.legAnim.IsWarpLoop, isVisiable);
			}
		}
	}
}
