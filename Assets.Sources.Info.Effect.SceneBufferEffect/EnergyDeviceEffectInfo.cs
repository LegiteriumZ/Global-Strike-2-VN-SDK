using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class EnergyDeviceEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "energydevice";

	protected override string GetPrefabName()
	{
		return "EnergyDevice";
	}

	public override Type GetRenderType()
	{
		return typeof(EnergyDeviceEffectRender);
	}
}
