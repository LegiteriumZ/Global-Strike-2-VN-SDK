using Assets.Sources.Components.Interface;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class JumpStartEndEffectRender : AbstractSceneBuffEffectRender
{
	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
		if (entity.HasSceneBuff)
		{
			effectGameObject.transform.Find("GameObject/2/sprite").localScale = Vector3.one * entity.SceneBuff.Data.Radius;
		}
	}
}
