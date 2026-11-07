using System.Collections;
using Assets.Generated.Table;
using SSJJAsset.AssetManager;
using UnityEngine;

namespace Assets.Sources.CsvLoader;

public class GameMessageLoader
{
	private static GameMessageLoader _instance;

	public static GameMessageLoader Instance => _instance ?? (_instance = new GameMessageLoader());

	public GameMessageTable Table { get; private set; }

	public GameMessageLoader()
	{
		Table = new GameMessageTable();
	}

	public IEnumerator Load()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync("tables", "GameMessage");
		TextAsset result = loader.Result;
		Table.Load(result.text);
	}
}
