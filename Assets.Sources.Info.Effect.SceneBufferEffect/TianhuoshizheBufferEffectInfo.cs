using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class TianhuoshizheBufferEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "TIANHUOSHIZHE_HUOYAN";

	protected override string GetAssetBundlePrefixName()
	{
		return string.Format("{0}justice_from_above", "weapon/");
	}

	protected override string GetPrefabName()
	{
		return "tianhuoshizhe_huoyan";
	}

	public override Type GetRenderType()
	{
		return typeof(TianhuoshizheEffectRender);
	}
}
