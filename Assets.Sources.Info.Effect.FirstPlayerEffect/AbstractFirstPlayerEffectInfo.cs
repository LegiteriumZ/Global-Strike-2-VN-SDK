using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.Effect;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.FirstPlayerEffect;

public abstract class AbstractFirstPlayerEffectInfo : IFirstPlayerEffectInfo
{
	private int[] _supportedRules;

	protected int[] SupportedRules
	{
		get
		{
			if (_supportedRules == null)
			{
				_supportedRules = GetSupportedRules();
			}
			return _supportedRules;
		}
	}

	public abstract bool IsEffectOn(PlayerEntity player, IBattleRoom room);

	public virtual AssetInfo GetFirstEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return new AssetInfo(GetAssetBundlePrefixName(), GetPrefabName());
	}

	protected abstract int[] GetSupportedRules();

	protected virtual string GetAssetBundlePrefixName()
	{
		return string.Format("{0}{1}", "firstplayereffectprefab/", GetPrefabName());
	}

	protected abstract string GetPrefabName();

	public virtual Type GetFirstRenderType()
	{
		return typeof(DefaultPlayerEffectRender);
	}

	public bool IsEffectOff(SceneObjectEntity entuty, PlayerEntity player, IBattleRoom room)
	{
		return false;
	}
}
