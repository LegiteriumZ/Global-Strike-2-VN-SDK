using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Entitas;
using UnityEngine;
using cakeslice;

namespace Assets.Sources.Modules.Player.Effect;

public class PlayerLoadOutlineSystem : IPlaybackSystem
{
	private IGroup<PlayerEntity> _group;

	public PlayerLoadOutlineSystem(Contexts contexts)
	{
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.ThirdPersonUnityObjects));
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity item in _group)
		{
			SkinnedMeshRenderer[] array;
			if (item.isOutline && !item.thirdPersonUnityObjects.OutLineAdded)
			{
				array = (RuleUtilty.EnableAvater() ? item.thirdPersonUnityObjects.ThirdTran.BodyTransform.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>() : item.thirdPersonUnityObjects.CareerSkins.ToArray());
				for (int i = 0; i < array.Length; i++)
				{
					array[i].gameObject.AddComponent<Outline>();
				}
				item.thirdPersonUnityObjects.OutLineAdded = true;
			}
			if (item.isOutline || !item.thirdPersonUnityObjects.OutLineAdded)
			{
				continue;
			}
			array = (RuleUtilty.EnableAvater() ? item.thirdPersonUnityObjects.ThirdTran.BodyTransform.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>() : item.thirdPersonUnityObjects.CareerSkins.ToArray());
			for (int i = 0; i < array.Length; i++)
			{
				Outline component = array[i].GetComponent<Outline>();
				if (component != null)
				{
					Object.Destroy(component);
				}
			}
			item.thirdPersonUnityObjects.OutLineAdded = false;
		}
	}
}
