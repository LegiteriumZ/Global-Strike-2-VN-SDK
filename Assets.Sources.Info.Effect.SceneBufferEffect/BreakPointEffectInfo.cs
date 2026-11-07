using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class BreakPointEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "breakpoint";

	protected override string GetPrefabName()
	{
		return "BreakPoint";
	}

	public override Type GetRenderType()
	{
		return typeof(BreakPointEffectRender);
	}
}
