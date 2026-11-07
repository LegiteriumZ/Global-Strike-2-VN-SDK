using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class StrongholdBufferEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "stronghold";

	protected override string GetPrefabName()
	{
		return "StrongholdBuffer";
	}

	public override Type GetRenderType()
	{
		return typeof(StrongholdBufferEffectRender);
	}
}
