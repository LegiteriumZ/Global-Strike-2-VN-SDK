using System.Collections;
using Assets.Generated.Table;
using SSJJAsset.AssetManager;
using UnityEngine;

namespace Assets.Sources.CsvLoader;

public class GameMessagePvpLoader
{
	private static GameMessagePvpLoader _instance;

	public static GameMessagePvpLoader Instance => _instance ?? (_instance = new GameMessagePvpLoader());

	public GameMessagePvpTable Table { get; private set; }

	public GameMessagePvpLoader()
	{
		Table = new GameMessagePvpTable();
	}

	public IEnumerator Load()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync("tables", "GameMessagePvp");
		TextAsset result = loader.Result;
		Table.Load(result.text);
	}
}
