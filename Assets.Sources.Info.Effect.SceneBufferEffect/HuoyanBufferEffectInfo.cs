using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class HuoyanBufferEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "buff_huoyan";

	protected override string GetPrefabName()
	{
		return "HuoyanBuffer";
	}

	public override Type GetRenderType()
	{
		return typeof(DefaultSceneBuffEffectRender);
	}
}
