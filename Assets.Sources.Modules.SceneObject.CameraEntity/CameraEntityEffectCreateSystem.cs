using Assets.Sources.Components.Interface.Info.CameraEffect;
using Assets.Sources.Components.SceneObject.PlayerEffect;
using Assets.Sources.Framework;
using Assets.Sources.Info.Effect.CameraEffect;
using Entitas;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.CameraEntity;

public class CameraEntityEffectCreateSystem : IEntityCreateSystem
{
	private SceneObjectContext _sceneObjectContext;

	private IGroup<SceneObjectEntity> _group;

	public CameraEntityEffectCreateSystem(Contexts contexts)
	{
		_sceneObjectContext = contexts.sceneObject;
		_group = _sceneObjectContext.GetGroup(SceneObjectMatcher.CameraObject);
	}

	public void OnEntityCreate()
	{
		int frameCount = Time.frameCount;
		int num = 0;
		foreach (SceneObjectEntity item in _group)
		{
			if ((frameCount - num++) % 10 == 0)
			{
				CreateEffect(item);
			}
		}
	}

	private void CreateEffect(SceneObjectEntity entity)
	{
		foreach (ICameraEffectInfo effectInfo in CameraEffectInfoFactory.Instance.EffectInfoList)
		{
			if (effectInfo.IsEffectOn(entity))
			{
				AddEffect(entity, effectInfo);
			}
		}
	}

	private void AddEffect(SceneObjectEntity entity, ICameraEffectInfo effectInfo)
	{
		EntityEffectId entityEffectId = new EntityEffectId(entity.cameraObject.Current.Id, effectInfo.GetTypeId());
		if (_sceneObjectContext.GetEntityWithPlayerEffectId(entityEffectId) == null)
		{
			AssetInfo assetInfo = effectInfo.GetAssetInfo();
			SceneObjectEntity sceneObjectEntity = _sceneObjectContext.CreateEntity();
			sceneObjectEntity.AddPlayerEffectId(entityEffectId);
			sceneObjectEntity.AddPosition(Vector3.zero);
			sceneObjectEntity.AddScale(Vector3.one);
			sceneObjectEntity.AddCameraEffect(entity.entityId.Value, effectInfo);
			sceneObjectEntity.AddLoadUnityObjects(new LoadRequests(assetInfo), entityEffectId);
		}
	}

	private static string GetEffectEntityId(int playerEntityId, string effectName)
	{
		return $"{playerEntityId}@{effectName}";
	}
}
