using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class TransmitSceneBuffEffectRender : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "TRANSMIT";

	protected override string GetPrefabName()
	{
		return "chuansongmen";
	}

	protected override string GetAssetBundlePrefixName()
	{
		return $"sceneobject/chuansongmen";
	}

	public override Type GetRenderType()
	{
		return typeof(BravebieberSceneEffectRender);
	}
}
