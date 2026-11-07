using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class GoHeSceneEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "SNAKE_CHAIN_SWORD_LINE";

	protected override string GetPrefabName()
	{
		return "gouhe";
	}

	protected override string GetAssetBundlePrefixName()
	{
		return $"weapon/snake_chain_sword2";
	}

	public override Type GetRenderType()
	{
		return typeof(BravebieberSceneEffectRender);
	}
}
