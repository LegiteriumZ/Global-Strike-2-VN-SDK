using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class GunFightFlagEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "Flag";

	protected override string GetPrefabName()
	{
		return "flag";
	}

	protected override string GetAssetBundlePrefixName()
	{
		return $"effect/gunFightMode";
	}

	public override Type GetRenderType()
	{
		return typeof(GunFightFlagEffectRender);
	}
}
