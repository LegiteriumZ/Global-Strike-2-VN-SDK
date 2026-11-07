using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class EnergyPrepareEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "ENERGY_PREPARE";

	protected override string GetPrefabName()
	{
		return "fuhuobao_zhunbei";
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
