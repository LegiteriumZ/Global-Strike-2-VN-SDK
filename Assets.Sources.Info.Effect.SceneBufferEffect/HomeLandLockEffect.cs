using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class HomeLandLockEffect : AbstractSceneBufferEffectInfo
{
	private string _buffName;

	public override string BuffName => "HOMELAND_LOCK";

	protected override string GetPrefabName()
	{
		return "jz";
	}

	protected override string GetAssetBundlePrefixName()
	{
		return $"effect/homemodel";
	}

	public override Type GetRenderType()
	{
		return typeof(BravebieberSceneEffectRender);
	}
}
