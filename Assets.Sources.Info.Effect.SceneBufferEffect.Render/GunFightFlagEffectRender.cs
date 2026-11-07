using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Sources.Info.Effect.SceneBufferEffect.Render;

public class GunFightFlagEffectRender : AbstractSceneBuffEffectRender
{
	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
	}

	public override void Render(int frameTime, IBattleRoom battleRoom)
	{
		base.Render(frameTime, battleRoom);
	}

	public override Vector3 GetRotation(SceneObjectEntity target)
	{
		return new Vector3(270f, 0f, 0f);
	}
}
