using System.Collections;
using Assets.Sources.Info.Weapon;
using SSJJAsset.AssetManager;
using UnityEngine;

namespace Assets.Sources.CsvLoader;

public class WeaponParitlceVisiableLoader
{
	public static WeaponParitlceVisiableLoader Instance = new WeaponParitlceVisiableLoader();

	public IEnumerator Load()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync("tables", "WeaponParticleVisiable");
		string text = loader.Result.text;
		PlayerAnimationTable playerAnimationTable = new PlayerAnimationTable();
		playerAnimationTable.Load(text);
		foreach (PlayerAnimationTable.Row row in playerAnimationTable.GetRowList())
		{
			WeaponParticleVisiableFactory.Instance.AddParticle(row.CareerName, row.AssetName);
		}
	}
}
