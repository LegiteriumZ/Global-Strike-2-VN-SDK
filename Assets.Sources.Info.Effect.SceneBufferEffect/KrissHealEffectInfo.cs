using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class KrissHealEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "kriss_heal";

	protected override string GetAssetBundlePrefixName()
	{
		return "weapon/p90_s2";
	}

	protected override string GetPrefabName()
	{
		return "kriss_cure";
	}

	public override Type GetRenderType()
	{
		return typeof(DefaultSceneBuffEffectRender);
	}
}
