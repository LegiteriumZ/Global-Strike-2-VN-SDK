using System.Collections;
using Assets.Generated.Table;
using SSJJAsset.AssetManager;
using UnityEngine;

namespace Assets.Sources.CsvLoader;

public class LocalEntityEffectLoader
{
	private static LocalEntityEffectLoader _instance;

	public static LocalEntityEffectLoader Instance => _instance ?? (_instance = new LocalEntityEffectLoader());

	public LocalEntityEffectTable Table { get; private set; }

	public LocalEntityEffectLoader()
	{
		Table = new LocalEntityEffectTable();
	}

	public IEnumerator Load()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync("tables", "LocalEntityEffect");
		TextAsset result = loader.Result;
		Table.Load(result.text);
	}
}
