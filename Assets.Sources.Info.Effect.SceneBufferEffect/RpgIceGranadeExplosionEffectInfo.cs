using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class RpgIceGranadeExplosionEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "PVE_ICE_GRENADE_EXPLOSION_QUYU";

	protected override string GetPrefabName()
	{
		return "RpgIceGranadeExplosion";
	}

	public override Type GetRenderType()
	{
		return typeof(DefaultSceneBuffEffectRender);
	}
}
