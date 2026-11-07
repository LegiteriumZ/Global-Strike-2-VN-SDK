using Assets.Sources.Utils.AssetManager;
using SSJJAsset.Asset;
using SSJJAvater;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Extensions;

public class GameUnityAvaterJob : UnityAvaterJob
{
	public string playerName;

	protected override Object LoadObject(string respath)
	{
		AssetInfo assetInfo = new AssetInfo($"player/{playerName}", $"Assets/Res/Assets/player/{playerName}/Prefabs/{respath}.prefab");
		return SingletonInstance<AssetPool>.Instance.GetOrNull(assetInfo) as Object;
	}
}
