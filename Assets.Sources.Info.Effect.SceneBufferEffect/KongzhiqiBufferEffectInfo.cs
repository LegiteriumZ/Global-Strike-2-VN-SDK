using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class KongzhiqiBufferEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "kongzhiqi";

	protected override string GetPrefabName()
	{
		return "Kongzhiqi";
	}

	public override Type GetRenderType()
	{
		return typeof(KongzhiqiBufferEffectRender);
	}
}
