using Assets.Sources.Components.Interface;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;
using NetData;
using UnityEngine;

namespace Assets.Sources.Info.Effect.LocalEntityEffect.Render;

public class SparyEffectRender : AbstractSceneBuffEffectRender
{
	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		if (((SceneObjectEntity)entity).localEntityEffect.EventData is SprayEventEntityData)
		{
			new Mesh().name = "Spary";
		}
	}

	public override void Render(int frameTime, IBattleRoom battleRoom)
	{
	}
}
