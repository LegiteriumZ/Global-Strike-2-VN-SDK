using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class GoHeCrystalSceneEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "SNAKE_CHAIN_SWORD_LINE_CRYSTAL";

	protected override string GetPrefabName()
	{
		return "gouhe_crystal";
	}

	protected override string GetAssetBundlePrefixName()
	{
		return $"weaponskin/skin_snake_chain_sword_crystal";
	}

	public override Type GetRenderType()
	{
		return typeof(BravebieberSceneEffectRender);
	}
}
