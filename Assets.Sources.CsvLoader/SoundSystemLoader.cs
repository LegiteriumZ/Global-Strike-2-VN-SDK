using System.Collections;
using Assets.Generated.Table;
using SSJJAsset.AssetManager;
using UnityEngine;

namespace Assets.Sources.CsvLoader;

public class SoundSystemLoader
{
	private static SoundSystemLoader _instance;

	public static SoundSystemLoader Instance => _instance ?? (_instance = new SoundSystemLoader());

	public SoundSystemTable Table { get; private set; }

	public SoundSystemLoader()
	{
		Table = new SoundSystemTable();
	}

	public IEnumerator Load()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync("tables", "SoundSystem");
		TextAsset result = loader.Result;
		Table.Load(result.text);
	}
}
