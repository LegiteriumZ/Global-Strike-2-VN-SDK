using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class GoHeSakuraSceneEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "SNAKE_CHAIN_SWORD_LINE_SAKYRA";

	protected override string GetPrefabName()
	{
		return "gouhe_sakura";
	}

	protected override string GetAssetBundlePrefixName()
	{
		return $"weaponskin/skin_snake_chain_sword_sakura";
	}

	public override Type GetRenderType()
	{
		return typeof(BravebieberSceneEffectRender);
	}
}
