using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class SkillBufferEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "SkillBufferEffectInfo";

	protected override string GetPrefabName()
	{
		return "SkillBuffer";
	}

	public override Type GetRenderType()
	{
		return typeof(SkillBufferEffectRender);
	}
}
