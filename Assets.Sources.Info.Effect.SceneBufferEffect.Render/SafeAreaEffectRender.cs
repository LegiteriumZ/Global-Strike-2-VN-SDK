using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Sources.Info.Effect.SceneBufferEffect.Render;

public class SafeAreaEffectRender : AbstractSceneBuffEffectRender
{
	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
		ParticleSystem[] componentsInChildren = effectGameObject.GetComponentsInChildren<ParticleSystem>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			ParticleSystem.MainModule main = componentsInChildren[i].main;
			main.scalingMode = ParticleSystemScalingMode.Hierarchy;
		}
	}

	public override void Render(int frameTime, IBattleRoom battleRoom)
	{
	}

	public override Vector3 GetRotation(SceneObjectEntity target)
	{
		return base.GetRotation(target);
	}
}
