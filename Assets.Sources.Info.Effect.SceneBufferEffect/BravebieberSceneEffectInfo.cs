using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class BravebieberSceneEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "bravebieber_scene";

	protected override string GetPrefabName()
	{
		return "bibo_pose";
	}

	protected override string GetAssetBundlePrefixName()
	{
		return $"weapon/bravebieber";
	}

	public override Type GetRenderType()
	{
		return typeof(BravebieberSceneEffectRender);
	}
}
