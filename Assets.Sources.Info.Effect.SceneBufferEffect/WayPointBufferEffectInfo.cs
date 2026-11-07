using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class WayPointBufferEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "kongzhiqi1";

	protected override string GetPrefabName()
	{
		return "WayPointBuffer";
	}

	public override Type GetRenderType()
	{
		return typeof(WayPointBufferEffectRender);
	}
}
