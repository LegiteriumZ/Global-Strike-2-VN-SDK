using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class AwakeningSceneEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "awakening_aoe";

	protected override string GetPrefabName()
	{
		return "skill_baofa";
	}

	protected override string GetAssetBundlePrefixName()
	{
		return $"weapon/awakening2";
	}

	public override Type GetRenderType()
	{
		return typeof(BravebieberSceneEffectRender);
	}
}
