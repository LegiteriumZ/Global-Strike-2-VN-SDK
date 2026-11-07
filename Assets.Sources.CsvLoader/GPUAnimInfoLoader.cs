using System.Collections;
using Assets.Res.Assets.Scripts.Sources.Info.GPUAnim;
using Assets.Sources.Info.GPUAnim;
using SSJJAsset.AssetManager;
using SSJJBase.Manager;
using UnityEngine;

namespace Assets.Sources.CsvLoader;

public class GPUAnimInfoLoader
{
	private static GPUAnimInfoLoader _instance;

	public static GPUAnimInfoLoader Instance => _instance ?? (_instance = new GPUAnimInfoLoader());

	private GPUAnimInfoTable Table { get; set; }

	public GPUAnimInfoLoader()
	{
		Table = new GPUAnimInfoTable();
	}

	public IEnumerator Load()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync("tables", "GPUAnimInfo");
		TextAsset result = loader.Result;
		Table.Load(result.text);
		foreach (GPUAnimInfoTable.Row row in Table.GetRowList())
		{
			BattleSingletonInstance<GpuAnimInfoFactory>.Instance.Add(new GPUAnimInfo(row.Name));
		}
	}
}
