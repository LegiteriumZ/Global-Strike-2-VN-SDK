using System;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class DistanceShowEffect : AbstractSceneBufferEffectInfo
{
	private string _buffName;

	public override string BuffName => "da_sha_qi_2024";

	public override Type GetRenderType()
	{
		return typeof(DistanceShowEffectRender);
	}

	protected override string GetAssetBundlePrefixName()
	{
		return "scenebuffeffectprefab/weaponbuffer";
	}

	protected override string GetPrefabName()
	{
		return "WeaponBuffer6";
	}
}
