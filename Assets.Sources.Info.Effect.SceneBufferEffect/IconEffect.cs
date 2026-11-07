using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class IconEffect : AbstractSceneBufferEffectInfo
{
	private string _buffName;

	public override string BuffName => "WIND_SPIRIT_TAG";

	protected override string GetPrefabName()
	{
		return "wind_spirit";
	}

	public override Type GetRenderType()
	{
		return typeof(IconSceneBuffEffectRender);
	}
}
