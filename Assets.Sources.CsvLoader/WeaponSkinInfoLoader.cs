using System.Collections;
using Assets.Sources.Info.Weapon;
using SSJJAsset.AssetManager;
using SSJJBase.Manager;
using UnityEngine;

namespace Assets.Sources.CsvLoader;

public class WeaponSkinInfoLoader
{
	private static WeaponSkinInfoLoader _instance;

	public static WeaponSkinInfoLoader Instance => _instance ?? (_instance = new WeaponSkinInfoLoader());

	public WeaponSkinInfoTable Table { get; private set; }

	public WeaponSkinInfoLoader()
	{
		Table = new WeaponSkinInfoTable();
	}

	public IEnumerator Load()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync("tables", "WeaponSkinInfo");
		TextAsset result = loader.Result;
		Table.Load(result.text);
		foreach (WeaponSkinInfoTable.Row row in Table.GetRowList())
		{
			BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.Add(new WeaponSkinInfo(row.Name, row.Multiple, row.QuenchPara, row.FirstLightDir, row.FollowLightDir)
			{
				HasBaseTexture = row.HasBaseTexture,
				HasSkinTexture = row.HasSkinTexture,
				HasViewModel = row.HasViewModel,
				HasViewAnim = row.HasViewAnim,
				HasThirdModel = row.HasThirdModel,
				HasSceneModel = row.HasSceneModel,
				HasEffect = row.HasEffect,
				HasKnifeEffect = row.HasKnifeEffect,
				HasEffectConfig = row.HasEffectConfig,
				Weapon = row.Weapon,
				HasWeaponPath = row.HasWeaponPath,
				HasQuench = row.HasQuench,
				QuenchPara = row.QuenchPara,
				FirstLightDir = row.FirstLightDir,
				IsCarbon = row.IsCarbon,
				FollowLightDiffDir = row.FollowLightDir,
				HasParticleLogic = row.HasParticleLogic,
				HasDyeingTexture = row.HasDyeingTexture
			});
		}
	}
}
