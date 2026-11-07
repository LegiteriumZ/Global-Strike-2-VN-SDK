using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class SafeAreaEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "SAFE_AREA";

	protected override string GetPrefabName()
	{
		return "duquan";
	}

	protected override string GetAssetBundlePrefixName()
	{
		return $"effect/bladefightmode";
	}

	public override Type GetRenderType()
	{
		return typeof(SafeAreaEffectRender);
	}
}
