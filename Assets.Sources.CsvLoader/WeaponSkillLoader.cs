using System;
using System.Collections;
using Assets.Generated.Table;
using Assets.Sources.Info.SkillProgress;
using SSJJAsset.AssetManager;
using SSJJBase.Logger;
using SSJJBase.Manager;
using UnityEngine;

namespace Assets.Sources.CsvLoader;

public class WeaponSkillLoader
{
	private static WeaponSkillLoader _instance;

	public static WeaponSkillLoader Instance => _instance ?? (_instance = new WeaponSkillLoader());

	public WeaponSkillTable Table { get; private set; }

	public WeaponSkillLoader()
	{
		Table = new WeaponSkillTable();
	}

	public IEnumerator Load()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync("tables", "WeaponSkill");
		TextAsset result = loader.Result;
		Table.Load(result.text);
		foreach (WeaponSkillTable.Row row in Table.GetRowList())
		{
			LoadWeaponSkillProgressData(row);
		}
	}

	private void LoadWeaponSkillProgressData(WeaponSkillTable.Row rowData)
	{
		try
		{
			ISkillProgressInfo skillProgressInfo = new DefaultSkillProgressInfo();
			BattleSingletonInstance<SkillProgressFactory>.Instance.SkillProgressInfos.Add(rowData.Id, skillProgressInfo);
			skillProgressInfo.Config = rowData;
			skillProgressInfo.Cd = ParseLogicParam("Assets.Sources.Info.SkillProgress.CanCd", "Cd", skillProgressInfo.Config.Cd.ToString()) as ICd;
			skillProgressInfo.CanUse = ParseLogicParam("Assets.Sources.Info.SkillProgress.CanUse", "CanUse", skillProgressInfo.Config.CanUse.ToString()) as ICanUse;
			skillProgressInfo.Progress = ParseLogicParam("Assets.Sources.Info.SkillProgress.Progress", "Progress", skillProgressInfo.Config.Type.ToString()) as IProgress;
			skillProgressInfo.Visiable = ParseLogicParam("Assets.Sources.Info.SkillProgress.Visiable", "Visiable", skillProgressInfo.Config.Mode.ToString()) as Assets.Sources.Info.SkillProgress.IVisiable;
			skillProgressInfo.Effect = ParseLogicParam("Assets.Sources.Info.SkillProgress.Effect", "Effect", skillProgressInfo.Config.Effect.ToString()) as IEffect;
			skillProgressInfo.Special = ParseLogicParam("Assets.Sources.Info.SkillProgress.Special", "Special", skillProgressInfo.Config.SpecialType.ToString()) as ISpecial;
			skillProgressInfo.ProgressVisiable = ParseLogicParam("Assets.Sources.Info.SkillProgress.ProgressVisiable", "ProgressVisiable", skillProgressInfo.Config.ProgressVisiable.ToString()) as IProgressVisiable;
		}
		catch (Exception ex)
		{
			this.LogErrorFormat("Load Error: WeaponName {0} Error {1}", rowData.Name, ex.ToString());
		}
	}

	private object ParseLogicParam(string namespaces, string classSuffix, string param)
	{
		string text = $"{namespaces}.{param}{classSuffix}";
		Type type = Type.GetType(text);
		if (type != null)
		{
			return Activator.CreateInstance(type);
		}
		this.LogErrorFormat("Parse Error: ClassName {0}", text);
		return null;
	}
}
