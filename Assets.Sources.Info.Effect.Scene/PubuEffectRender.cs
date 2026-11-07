using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Info.Effect.Scene;

public class PubuEffectRender : AbstractSceneEffectRender
{
	public PubuEffectRender(SceneEffectData effectData)
	{
		EffectData = effectData;
	}

	public override void Init(SceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
		effectGameObject.transform.localPosition = VectorCoordConverter.SsjjToUnity(EffectData.Position);
		effectGameObject.transform.eulerAngles = VectorCoordConverter.SsjjToUnity(EffectData.Rotation);
	}

	public override void Render(int frameTime, SceneObjectEntity entity)
	{
		if (EffectObject == null && entity.hasUnityObjects)
		{
			Init(entity, entity.unityObjects.LoadResults[0].GameObject);
		}
	}
}
