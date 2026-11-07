using System.Collections;
using Assets.Generated.Table;
using SSJJAsset.AssetManager;
using UnityEngine;

namespace Assets.Sources.CsvLoader;

public class AcgInfoLoader
{
	private static AcgInfoLoader _instance;

	public static AcgInfoLoader Instance => _instance ?? (_instance = new AcgInfoLoader());

	public AcgAttributesTable AcgAttributesTable { get; private set; }

	public AcgPowerUpsTable AcgPowerUpsTable { get; private set; }

	public AcgInfoLoader()
	{
		AcgAttributesTable = new AcgAttributesTable();
		AcgPowerUpsTable = new AcgPowerUpsTable();
	}

	public IEnumerator Load()
	{
		AssetAsyncLoader<TextAsset> loader2 = new AssetAsyncLoader<TextAsset>();
		yield return loader2.LoadAsync("tables", "AcgAttributes");
		TextAsset result = loader2.Result;
		AcgAttributesTable.Load(result.text);
		loader2 = new AssetAsyncLoader<TextAsset>();
		yield return loader2.LoadAsync("tables", "AcgPowerUps");
		result = loader2.Result;
		AcgPowerUpsTable.Load(result.text);
	}
}
