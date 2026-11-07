using System.Collections;
using SSJJAnim.CareerAnim;
using SSJJAsset.AssetManager;
using SSJJBase.Manager;
using UnityEngine;

namespace Assets.Sources.CsvLoader;

internal class PlayerAnimationLoader
{
	private static PlayerAnimationLoader _instance;

	public static PlayerAnimationLoader Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new PlayerAnimationLoader();
			}
			return _instance;
		}
	}

	public IEnumerator Load()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return LoadPlayerAnimationAsync(loader);
	}

	private static IEnumerator LoadPlayerAnimationAsync(AssetAsyncLoader<TextAsset> loader)
	{
		yield return loader.LoadAsync("tables", "PlayerAnimation");
		string text = loader.Result.text;
		PlayerAnimationTable playerAnimationTable = new PlayerAnimationTable();
		playerAnimationTable.Load(text);
		foreach (PlayerAnimationTable.Row row in playerAnimationTable.GetRowList())
		{
			BattleSingletonInstance<CareerAnimInfoFactory>.Instance.AddCareerAnimation(row.CareerName, row.AssetName);
		}
	}
}
