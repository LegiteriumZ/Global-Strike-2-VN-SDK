using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class GoHeElecSceneEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "SNAKE_CHAIN_SWORD_LINE_ELEC";

	protected override string GetPrefabName()
	{
		return "gouhe_elec";
	}

	protected override string GetAssetBundlePrefixName()
	{
		return $"weaponskin/skin_snake_chain_sword_elec";
	}

	public override Type GetRenderType()
	{
		return typeof(BravebieberSceneEffectRender);
	}
}
