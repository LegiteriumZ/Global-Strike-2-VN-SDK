using System.Collections;
using Assets.Generated.Table;
using Assets.Sources.Info.Map;
using SSJJAsset.AssetManager;
using SSJJBase.Manager;
using UnityEngine;

namespace Assets.Sources.CsvLoader;

public class MapInfoLoader
{
	private static MapInfoLoader _instance;

	public static MapInfoLoader Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new MapInfoLoader();
			}
			return _instance;
		}
	}

	public IEnumerator Load()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync("tables", "Map");
		string text = loader.Result.text;
		MapTable mapTable = new MapTable();
		mapTable.Load(text);
		foreach (MapTable.Row row in mapTable.GetRowList())
		{
			LoadMapData(row);
		}
	}

	private void LoadMapData(MapTable.Row rowData)
	{
		DefaultMapInfo defaultMapInfo = new DefaultMapInfo(rowData.Id);
		defaultMapInfo.Name = rowData.Name;
		defaultMapInfo.DataType = rowData.DataType;
		BattleSingletonInstance<MapInfoFactory>.Instance.Add(defaultMapInfo);
	}
}
