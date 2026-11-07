using System;
using Assets.Sources.Info.Effect.PlayerEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class RobChickenBufferEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "buff_robchicken";

	protected override string GetPrefabName()
	{
		return "RobChicken";
	}

	public override Type GetRenderType()
	{
		return typeof(RobChickenBufferEffectRender);
	}
}
