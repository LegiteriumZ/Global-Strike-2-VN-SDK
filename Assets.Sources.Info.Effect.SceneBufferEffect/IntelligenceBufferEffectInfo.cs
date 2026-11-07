using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class IntelligenceBufferEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "intelligence";

	protected override string GetPrefabName()
	{
		return "Intelligence";
	}

	public override Type GetRenderType()
	{
		return typeof(DefaultSceneBuffEffectRender);
	}
}
