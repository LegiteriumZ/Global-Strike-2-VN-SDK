using Assets.Sources.Framework;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson;

public class OrientationAnimSystem : IPlaybackSystem
{
	private readonly IGroup<PlayerEntity> _players;

	public OrientationAnimSystem(Contexts contexts)
	{
		_players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ThirdPersonUnityObjects, PlayerMatcher.Orientation).NoneOf(PlayerMatcher.ThirdPersonGPUAnim));
	}

	public void OnRender()
	{
		foreach (PlayerEntity player in _players)
		{
			SetOrientaionGenLegAnim(player);
		}
	}

	public void OnPlayback()
	{
		OnRender();
	}

	private void SetOrientaionGenLegAnim(PlayerEntity entity)
	{
		if (Mathf.Approximately(entity.thirdPersonUnityObjects.Animator.GetParameter("Clip4Back"), 1f))
		{
			Transform transform = entity.thirdPersonUnityObjects.ThirdTran.RootContainer.transform;
			Vector3 eulerAngles = transform.localRotation.eulerAngles;
			eulerAngles.y = 0f - entity.orientation.Yaw;
			transform.localRotation = Quaternion.Euler(eulerAngles);
		}
	}
}
