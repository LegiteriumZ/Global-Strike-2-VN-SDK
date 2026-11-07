using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Sources.Info.Effect.SceneBufferEffect.Render;

public class BravebieberSceneEffectRender : AbstractSceneBuffEffectRender
{
	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
	}

	public override void Render(int frameTime, IBattleRoom battleRoom)
	{
	}

	public override Vector3 GetRotation(SceneObjectEntity target)
	{
		return new Vector3(target.sceneBuff.Data.Roll, 0f - target.sceneBuff.Data.Yaw - 90f, target.sceneBuff.Data.Pitch);
	}
}
