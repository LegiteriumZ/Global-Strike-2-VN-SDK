using System.Collections;
using Assets.Sources.Info.Career;
using SSJJAsset.AssetManager;
using UnityEngine;

namespace Assets.Sources.CsvLoader;

public class PlayerSkinInfoLoader
{
	private static PlayerSkinInfoLoader _instance;

	public static PlayerSkinInfoLoader Instance => _instance ?? (_instance = new PlayerSkinInfoLoader());

	public PlayerSkinInfoTable Table { get; private set; }

	public PlayerSkinInfoLoader()
	{
		Table = new PlayerSkinInfoTable();
	}

	public IEnumerator Load()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync("tables", "PlayerSkinInfo");
		TextAsset result = loader.Result;
		Table.Load(result.text);
		foreach (PlayerSkinInfoTable.Row row in Table.GetRowList())
		{
			PlayerSkinInfoFactory.Instance.Add(new PlayerSkinInfo(row.Name)
			{
				HasSkinTexture = row.HasSkinTexture,
				HasThirdModel = row.HasThirdModel,
				HasViewHandModel = row.HasViewHandModel,
				HasEffect = row.HasEffect,
				HasEffectConfig = row.HasEffectConfig,
				PlayerName = row.Player,
				HasHitBox = row.HasHitBox,
				HasTextureConfig = row.HasTextureConfig,
				HasDyeing = row.HasDyeing
			});
		}
	}
}
