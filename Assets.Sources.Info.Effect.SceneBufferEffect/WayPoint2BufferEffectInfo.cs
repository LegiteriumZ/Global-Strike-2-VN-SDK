using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class WayPoint2BufferEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "kongzhiqi2";

	protected override string GetPrefabName()
	{
		return "WayPointBuffer";
	}

	public override Type GetRenderType()
	{
		return typeof(WayPointBufferEffectRender);
	}
}
