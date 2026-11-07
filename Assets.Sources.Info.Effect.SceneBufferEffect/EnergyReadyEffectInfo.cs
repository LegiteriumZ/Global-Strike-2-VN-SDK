using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class EnergyReadyEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "ENERGY_READY";

	protected override string GetPrefabName()
	{
		return "fuhuobao_shuaxin";
	}

	protected override string GetAssetBundlePrefixName()
	{
		return $"effect/bladefightmode";
	}

	public override Type GetRenderType()
	{
		return typeof(DefaultSceneBuffEffectRender);
	}
}
