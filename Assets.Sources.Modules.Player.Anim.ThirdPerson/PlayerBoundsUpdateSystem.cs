using Assets.Sources.Framework;
using Entitas;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson;

public class PlayerBoundsUpdateSystem : IPlaybackSystem
{
	private IGroup<PlayerEntity> _group;

	public PlayerBoundsUpdateSystem(Contexts contexts)
	{
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ThirdPersonUnityObjects, PlayerMatcher.Move, PlayerMatcher.Fpos));
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity item in _group)
		{
			Vector3 currentMin = item.basicInfo.CareerInfo.GetCurrentMin(item.move.DuckState);
			Vector3 currentMax = item.basicInfo.CareerInfo.GetCurrentMax(item.move.DuckState);
			Vector3 vector = (currentMin + currentMax) / 2f;
			Vector3 center = VectorCoordConverter.SsjjToUnity(item.GetCompenstatePos(item.fpos.Change.GetPosIndex()) + vector);
			Vector3 vector2 = VectorCoordConverter.SsjjToUnity(currentMax - currentMin);
			item.thirdPersonUnityObjects.Animator.Bounds = new Bounds(center, new Vector3(Mathf.Abs(vector2.x), Mathf.Abs(vector2.y), Mathf.Abs(vector2.z)));
		}
	}
}
