using System;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Info.Effect.Scene;

public class SnowEffectRender : AbstractSceneEffectRender
{
	public SnowEffectRender(SceneEffectData effectData)
	{
		EffectData = effectData;
	}

	public override void Init(SceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
		Vector3 vector = VectorCoordConverter.SsjjToUnity(EffectData.Pos0);
		Vector3 vector2 = VectorCoordConverter.SsjjToUnity(EffectData.Pos1);
		Vector3 vector3 = VectorCoordConverter.SsjjToUnity(EffectData.Pos2);
		Vector3 vector4 = VectorCoordConverter.SsjjToUnity(EffectData.Pos3);
		float num = Math.Min(vector.x, Math.Min(vector2.x, Math.Min(vector3.x, vector4.x)));
		float num2 = Math.Max(vector.x, Math.Max(vector2.x, Math.Max(vector3.x, vector4.x)));
		float num3 = Math.Min(vector.y, Math.Min(vector2.y, Math.Min(vector3.y, vector4.y)));
		float num4 = Math.Max(vector.y, Math.Max(vector2.y, Math.Max(vector3.y, vector4.y)));
		float num5 = Math.Min(vector.z, Math.Min(vector2.z, Math.Min(vector3.z, vector4.z)));
		float num6 = Math.Max(vector.z, Math.Max(vector2.z, Math.Max(vector3.z, vector4.z)));
		effectGameObject.transform.localPosition = new Vector3(num2 + num, num4 + num3, num6 + num5) * 0.5f;
		ParticleSystem.ShapeModule shape = effectGameObject.GetComponent<ParticleSystem>().shape;
		shape.scale = new Vector3(num2 - num, num4 - num3, num6 - num5);
	}

	public override void Render(int frameTime, SceneObjectEntity entity)
	{
		if (EffectObject == null && entity.hasUnityObjects)
		{
			Init(entity, entity.unityObjects.LoadResults[0].GameObject);
		}
	}
}
