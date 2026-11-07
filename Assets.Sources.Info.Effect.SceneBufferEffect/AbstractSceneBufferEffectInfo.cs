using System;
using Assets.Sources.Components.Interface.Info.Effect;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public abstract class AbstractSceneBufferEffectInfo : ISceneBufferEffectInfo
{
	public abstract string BuffName { get; }

	public virtual AssetInfo GetEffectAssetInfo(string bufname, bool isParticle)
	{
		return new AssetInfo(GetAssetBundlePrefixName(), GetPrefabName());
	}

	protected virtual string GetAssetBundlePrefixName()
	{
		return string.Format("{0}{1}", "scenebuffeffectprefab/", GetPrefabName());
	}

	protected abstract string GetPrefabName();

	public virtual Type GetRenderType()
	{
		return typeof(DefaultPlayerEffectRender);
	}
}
