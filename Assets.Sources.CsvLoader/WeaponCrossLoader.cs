using System.Collections;
using Assets.Generated.Table;
using SSJJAsset.AssetManager;
using UnityEngine;

namespace Assets.Sources.CsvLoader;

public class WeaponCrossLoader
{
	private static WeaponCrossLoader _instance;

	public static WeaponCrossLoader Instance => _instance ?? (_instance = new WeaponCrossLoader());

	public WeaponCrossTable Table { get; private set; }

	public WeaponCrossLoader()
	{
		Table = new WeaponCrossTable();
	}

	public IEnumerator Load()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync("tables", "WeaponCross");
		TextAsset result = loader.Result;
		Table.Load(result.text);
	}
}
