using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class PveBuySkillBufferEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "buy_skill";

	protected override string GetPrefabName()
	{
		return "PveBuy";
	}

	public override Type GetRenderType()
	{
		return typeof(PveBuyBufferEffectRender);
	}
}
