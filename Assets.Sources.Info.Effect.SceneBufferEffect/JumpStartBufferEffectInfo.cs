using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class JumpStartBufferEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "jump_start";

	protected override string GetPrefabName()
	{
		return "JumpStartEnd";
	}

	public override Type GetRenderType()
	{
		return typeof(JumpStartEndEffectRender);
	}
}
