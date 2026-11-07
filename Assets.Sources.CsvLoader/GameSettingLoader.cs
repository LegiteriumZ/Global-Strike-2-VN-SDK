using System.Collections;
using Assets.Generated.Table;
using SSJJAsset.AssetManager;
using UnityEngine;

namespace Assets.Sources.CsvLoader;

public class GameSettingLoader
{
	private static GameSettingLoader _instance;

	public static GameSettingLoader Instance => _instance ?? (_instance = new GameSettingLoader());

	public GameSettingTable Table { get; private set; }

	public GameSettingLoader()
	{
		Table = new GameSettingTable();
	}

	public IEnumerator Load()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync("tables", "GameSetting");
		TextAsset result = loader.Result;
		Table.Load(result.text);
	}
}
