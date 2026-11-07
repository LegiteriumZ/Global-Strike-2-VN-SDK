using System;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Info.Effect.Scene;

public class WaterEffectRender : AbstractSceneEffectRender
{
	public WaterEffectRender(SceneEffectData effectData)
	{
		EffectData = effectData;
	}

	public override void Init(SceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
		Vector3 vector = VectorCoordConverter.SsjjToUnity(EffectData.EnvBoxMin);
		Vector3 vector2 = VectorCoordConverter.SsjjToUnity(EffectData.EnvBoxMax);
		Vector3 vector3 = VectorCoordConverter.SsjjToUnity(EffectData.EnvBoxPos);
		float x = Math.Min(vector.x, vector2.x);
		float x2 = Math.Max(vector.x, vector2.x);
		float y = Math.Min(vector.y, vector2.y);
		float y2 = Math.Max(vector.y, vector2.y);
		float z = Math.Min(vector.z, vector2.z);
		float z2 = Math.Max(vector.z, vector2.z);
		effectGameObject.transform.localPosition = VectorCoordConverter.SsjjToUnity(EffectData.Position);
		Material material = effectGameObject.GetComponent<MeshRenderer>().material;
		material.SetVector("_EnvBoxMin", new Vector3(x, y, z));
		material.SetVector("_EnvBoxMax", new Vector3(x2, y2, z2));
		material.SetVector("_EnvBoxPos", vector3);
	}

	public override void Render(int frameTime, SceneObjectEntity entity)
	{
		if (EffectObject == null && entity.hasUnityObjects)
		{
			Init(entity, entity.unityObjects.LoadResults[0].GameObject);
		}
	}
}
