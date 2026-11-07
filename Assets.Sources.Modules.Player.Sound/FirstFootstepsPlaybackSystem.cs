using UnityEngine;

namespace Assets.Sources.Modules.Player.Sound;

internal class FirstFootstepsPlaybackSystem : FootstepsPlaybackSystem
{
	private readonly WorldCameraContext _worldCameraContext;

	public FirstFootstepsPlaybackSystem(Contexts contexts)
	{
		Players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.Fpos, PlayerMatcher.Move, PlayerMatcher.FirstPersonUnityObjects));
		_worldCameraContext = contexts.worldCamera;
	}

	protected override FootstepControl GetFootstepControl(PlayerEntity playerEntity)
	{
		FootstepControl footstepControl = _worldCameraContext.unityObjects.nodeEye.GetComponentInChildren<FootstepControl>();
		if (footstepControl == null)
		{
			GameObject gameObject = new GameObject("footstep");
			footstepControl = gameObject.AddComponent<FootstepControl>();
			gameObject.transform.parent = _worldCameraContext.unityObjects.nodeEye.transform;
			gameObject.transform.localPosition = Vector3.zero;
		}
		return footstepControl;
	}
}
