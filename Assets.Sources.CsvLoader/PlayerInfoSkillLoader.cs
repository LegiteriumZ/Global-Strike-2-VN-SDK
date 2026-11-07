using System.Collections;
using Assets.Generated.Table;
using SSJJAsset.AssetManager;
using UnityEngine;

namespace Assets.Sources.CsvLoader;

public class PlayerInfoSkillLoader
{
	private static PlayerInfoSkillLoader _instance;

	public static PlayerInfoSkillLoader Instance => _instance ?? (_instance = new PlayerInfoSkillLoader());

	public PlayerInfoSkillTable Table { get; private set; }

	public PlayerInfoSkillLoader()
	{
		Table = new PlayerInfoSkillTable();
	}

	public IEnumerator Load()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync("tables", "PlayerInfoSkill");
		TextAsset result = loader.Result;
		Table.Load(result.text);
	}
}
