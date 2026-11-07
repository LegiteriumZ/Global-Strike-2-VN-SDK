using System.Collections;
using Assets.Sources.Info.Res;
using SSJJAsset.AssetManager;
using SSJJBase.Manager;
using UnityEngine;

namespace Assets.Sources.CsvLoader;

internal class CommonParticleResLoader
{
	private static CommonParticleResLoader _instance;

	public static CommonParticleResLoader Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new CommonParticleResLoader();
			}
			return _instance;
		}
	}

	public IEnumerator Load()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return LoadCommonParticleResAsync(loader);
	}

	private static IEnumerator LoadCommonParticleResAsync(AssetAsyncLoader<TextAsset> loader)
	{
		yield return loader.LoadAsync("tables", "CommonParticleRes");
		string text = loader.Result.text;
		CommonParticleResTable commonParticleResTable = new CommonParticleResTable();
		commonParticleResTable.Load(text);
		foreach (CommonParticleResTable.Row row in commonParticleResTable.GetRowList())
		{
			BattleSingletonInstance<ResConfigFactory>.Instance.Add(new CommonParticleResConfig(row.Name, row.AssetBundle, row.AssetPath, row.Type, row.YawTrim, row.PitchTrim));
		}
	}
}
