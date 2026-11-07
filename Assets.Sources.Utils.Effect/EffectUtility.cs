using SSJJAsset.Asset;

namespace Assets.Sources.Utils.Effect;

public class EffectUtility
{
	public static AssetInfo GetCommonEffectAssetInfo(string effectName)
	{
		return new AssetInfo("effect/common", string.Format("Assets/Res/Assets/effect/common/{0}/Prefab/{0}.prefab", effectName));
	}

	public static AssetInfo GetEffectAssetInfo(string modeName, string effectName)
	{
		return new AssetInfo("effect/" + modeName, string.Format("Assets/Res/Assets/effect/{0}/{1}/Prefab/{1}.prefab", modeName, effectName));
	}
}
