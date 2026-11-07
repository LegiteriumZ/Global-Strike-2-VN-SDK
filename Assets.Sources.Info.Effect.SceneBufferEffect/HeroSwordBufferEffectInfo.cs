using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class HeroSwordBufferEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "HEROSWORD";

	protected override string GetPrefabName()
	{
		return "HeroSwordBufferr";
	}

	public override Type GetRenderType()
	{
		return typeof(HeroSwordBufferEffectRender);
	}
}
