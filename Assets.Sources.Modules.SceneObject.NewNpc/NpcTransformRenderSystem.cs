using Assets.Sources.Framework;
using Entitas;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.NewNpc;

public class NpcTransformRenderSystem : IRenderSystem
{
	private IGroup<SceneObjectEntity> _group;

	public NpcTransformRenderSystem(Contexts contexts)
	{
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.NpcUnityObjects));
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity item in _group)
		{
			bool flag = !item.hasVisiable || item.visiable.IsVisiable || item.visiable.IsNear;
			if (item.hasPosition && flag)
			{
				item.npcUnityObjects.RootContainer.transform.position = VectorCoordConverter.SsjjToUnity(item.position.Origin);
			}
			if (item.hasRotation && flag)
			{
				item.npcUnityObjects.RootContainer.transform.localEulerAngles = VectorCoordConverter.SsjjRotationToUnity(item.rotation.EulerAngles);
			}
			if (item.hasScale && flag)
			{
				item.npcUnityObjects.RootContainer.transform.localScale = VectorCoordConverter.SsjjScaleToUnity(item.scale.Scale);
			}
			if (item.npcBasicInfo.Current.Species == 2 && item.npcBasicInfo.Current.Cid == Contexts.sharedInstance.player.myPlayerEntity.basicInfo.Current.Id)
			{
				Transform transform = Contexts.sharedInstance.worldCamera.unityObjects.mainCamera.transform;
				Vector3 vector = transform.rotation * (Vector3.forward * item.npcBasicInfo.Current.EffectData + Vector3.left * item.npcBasicInfo.Current.Px + Vector3.up * item.npcBasicInfo.Current.Py);
				item.npcUnityObjects.RootContainer.transform.position = transform.position + vector;
				item.npcUnityObjects.RootContainer.transform.localEulerAngles = transform.eulerAngles;
			}
		}
	}
}
