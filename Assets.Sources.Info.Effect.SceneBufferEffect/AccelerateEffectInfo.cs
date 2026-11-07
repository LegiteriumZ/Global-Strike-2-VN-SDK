using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class AccelerateEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "acceleratebuf";

	protected override string GetPrefabName()
	{
		return "SceneBuffer";
	}

	public override Type GetRenderType()
	{
		return typeof(SceneBufferEffectRender);
	}
}
