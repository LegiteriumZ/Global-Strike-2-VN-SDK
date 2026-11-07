using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class ShutterFlashbangTagEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "SHUTTER_FLASHBANG_GIDENESS_TAG";

	protected override string GetPrefabName()
	{
		return "ShutterFlashbangTag";
	}

	public override Type GetRenderType()
	{
		return typeof(ShutterFlashbangTagEffectRender);
	}
}
