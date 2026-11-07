using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Effect;

public class MeshLodSystem : IRenderSystem
{
	private readonly IGroup<PlayerEntity> _group;

	private readonly IGroup<SceneObjectEntity> _sceneGroup;

	public MeshLodSystem(Contexts contexts)
	{
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ThirdPersonUnityObjects, PlayerMatcher.Lod).NoneOf(PlayerMatcher.Destroy));
		_sceneGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.NpcBasicInfo, SceneObjectMatcher.NpcUnityObjects, SceneObjectMatcher.Lod).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnRender()
	{
		if (!GameController.Instance.IsOpenLod)
		{
			return;
		}
		int frameCount = Time.frameCount;
		bool uiCross_AwpVisible = UiIEventCondition.Get_uiCross_AwpVisible();
		foreach (PlayerEntity item in _group)
		{
			foreach (ILODSwitcher item2 in item.lod.Switcher)
			{
				item2?.UpdateLod(frameCount, uiCross_AwpVisible);
			}
		}
		foreach (SceneObjectEntity item3 in _sceneGroup)
		{
			foreach (ILODSwitcher item4 in item3.lod.Switcher)
			{
				item4?.UpdateLod(frameCount, uiCross_AwpVisible);
			}
		}
	}
}
