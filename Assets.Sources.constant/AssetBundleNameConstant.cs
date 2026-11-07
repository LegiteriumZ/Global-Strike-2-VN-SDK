using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Constant;

internal class AssetBundleNameConstant
{
	public const string Common = "Scenes/scene_common_asset";

	public const string Fx = "fx_asset";

	public const string EffectPrefabPrefix = "effectprefab/";

	public const string PlayerEffectPrefabPrefix = "playereffectprefab/";

	public const string PlayerPrefix = "player/";

	public const string WeaponPrefix = "weapon/";

	public const string WeaponSkinPrefix = "weaponskin/";

	public const string EffectPrefix = "effect/";

	public const string SkillPrefix = "skill/";

	public const string SceneBufferEffectPrefix = "scenebuffeffectprefab/";

	public const string LocalEntityEffectPrefix = "localentityeffectprefab/";

	public const string FirstPlayerEffectPrefabPrefix = "firstplayereffectprefab/";

	public static AssetInfo GetPlayerEffectPrefabAssetInfo(string prefabName)
	{
		return new AssetInfo(string.Format("{0}{1}", "playereffectprefab/", prefabName), prefabName);
	}

	public static AssetInfo GetSceneEffectPrefabAssetInfo(string prefabName)
	{
		return new AssetInfo(string.Format("{0}{1}", "sceneeffectprefab/", prefabName), prefabName, typeof(GameObject), optional: true);
	}
}
