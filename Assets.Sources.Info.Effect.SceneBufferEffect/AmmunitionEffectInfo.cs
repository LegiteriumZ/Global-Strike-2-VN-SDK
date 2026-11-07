using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class AmmunitionEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "ammunition";

	protected override string GetPrefabName()
	{
		return "ammunition";
	}

	public override Type GetRenderType()
	{
		return typeof(DefaultSceneBuffEffectRender);
	}
}
