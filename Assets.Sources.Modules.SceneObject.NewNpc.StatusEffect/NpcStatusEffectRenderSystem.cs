using Assets.Sources.Framework;
using Entitas;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.NewNpc.StatusEffect;

public class NpcStatusEffectRenderSystem : IRenderSystem
{
	private IGroup<SceneObjectEntity> _group;

	private SceneObjectContext _sceneObjectContext;

	public NpcStatusEffectRenderSystem(Contexts contexts)
	{
		_sceneObjectContext = contexts.sceneObject;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.NpcStatusEffect));
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity item in _group)
		{
			SceneObjectEntity entityWithEntityId = _sceneObjectContext.GetEntityWithEntityId(item.npcStatusEffect.NpcEntityId);
			if (entityWithEntityId == null || ((int)entityWithEntityId.npcBasicInfo.Current.SkillEffectLevel & item.npcStatusEffect.SkillEffectLevel) == 0)
			{
				item.isDestroy = true;
			}
			else if (item.hasUnityObjects)
			{
				GameObject gameObject = item.unityObjects.LoadResults[0].GameObject;
				gameObject.transform.position = VectorCoordConverter.SsjjToUnity(entityWithEntityId.position.Origin);
				gameObject.transform.localEulerAngles = VectorCoordConverter.SsjjRotationToUnity(entityWithEntityId.rotation.EulerAngles);
			}
		}
	}
}
