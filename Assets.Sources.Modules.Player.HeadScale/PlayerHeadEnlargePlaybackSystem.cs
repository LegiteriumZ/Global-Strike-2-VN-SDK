using Assets.Sources.Framework;
using Entitas;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Modules.Player.HeadScale;

public class PlayerHeadEnlargePlaybackSystem : IPlaybackSystem
{
	private IGroup<PlayerEntity> _group;

	public PlayerHeadEnlargePlaybackSystem(Contexts contexts)
	{
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.HeadScale, PlayerMatcher.ThirdPersonUnityObjects));
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity item in _group)
		{
			Transform headTransform = item.thirdPersonUnityObjects.ThirdTran.HeadTransform;
			if (headTransform != null)
			{
				float num = 1f;
				if (PlayerCareerUtil.IsHumanity(item.GetCareer()))
				{
					num = item.thirdPersonUnityObjects.ThirdTran.HeadSize;
				}
				headTransform.localScale = Vector3.one * item.headScale.Scale * num;
			}
		}
	}
}
