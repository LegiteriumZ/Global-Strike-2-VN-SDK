using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class WeaponBufferEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "weapon";

	protected override string GetPrefabName()
	{
		return "WeaponBuffer";
	}

	public override Type GetRenderType()
	{
		return typeof(WeaponBuffEffectRender);
	}
}
