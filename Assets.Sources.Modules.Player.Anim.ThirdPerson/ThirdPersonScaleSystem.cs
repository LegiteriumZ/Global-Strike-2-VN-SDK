using Assets.Sources.Framework;
using Assets.Sources.Framework.System;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson;

internal class ThirdPersonScaleSystem : FrameExecuteSystem, IRenderSystem
{
	private readonly IGroup<PlayerEntity> _initGroup;

	public ThirdPersonScaleSystem(Contexts contexts)
	{
		_initGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.ThirdPersonUnityObjects));
	}

	public void OnRender()
	{
		if (!Frame())
		{
			return;
		}
		foreach (PlayerEntity item in _initGroup)
		{
			if (!item.hasThirdPersonUnityObjects)
			{
				continue;
			}
			Transform bodyTransform = item.thirdPersonUnityObjects.ThirdTran.BodyTransform;
			if (bodyTransform != null)
			{
				Transform parent = bodyTransform.transform.parent;
				if ((bool)parent)
				{
					parent.transform.localScale = Vector3.one * (1f + item.basicInfo.Current.Scale);
				}
			}
		}
	}
}
