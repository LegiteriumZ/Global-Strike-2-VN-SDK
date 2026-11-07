using Assets.Scripts.Effect.Level;
using Assets.Sources.Framework;
using Assets.Sources.Utils;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.MoveObject;

internal class MoveObjectRenderSystem : IRenderSystem
{
	private readonly IGroup<SceneObjectEntity> _group;

	public MoveObjectRenderSystem(Contexts contexts)
	{
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.MoveObject, SceneObjectMatcher.UnityObjects, SceneObjectMatcher.Rotation, SceneObjectMatcher.Position).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity item in _group)
		{
			item.moveObject.Info.RenderEntity(item);
			if (!item.hasMoveObjectAddEffect)
			{
				item.AddMoveObjectAddEffect(newIsAddEffect: true);
				ParticleEffectUtility.InitSceneParticle(item.unityObjects.LoadResults[0].GameObject, item.unityObjects.LoadResults[0].AssetInfo.AssetName);
			}
			if (!item.hasAddParticleLod)
			{
				item.AddAddParticleLod(newIsAdd: true);
				if (item.unityObjects.LoadResults != null && item.unityObjects.LoadResults.ContainsKey(0))
				{
					LodUtility.AddInstanceLod(item.unityObjects.LoadResults[0].GameObject);
				}
			}
		}
	}
}
