using System.Collections;
using Assets.Generated.Table;
using Assets.Sources.Particle;
using Assets.Sources.Utils.AssetManager;
using Assets.Sources.XmlAsset;
using SSJJAsset.Asset;
using SSJJAsset.AssetManager;
using SSJJBase.Singleton;
using SSJJBase.Thread;
using UnityEngine;

namespace Assets.Sources.CsvLoader;

public class SceneBuffLoader
{
	private static SceneBuffLoader _instance;

	public static SceneBuffLoader Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new SceneBuffLoader();
			}
			return _instance;
		}
	}

	public SceneBuffTable Table { get; private set; }

	public SceneBuffLoader()
	{
		Table = new SceneBuffTable();
	}

	public IEnumerator Load()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync("tables", "SceneBuff");
		TextAsset result = loader.Result;
		Table.Load(result.text);
		foreach (SceneBuffTable.Row row in Table.GetRowList())
		{
			yield return LoadSceneBuffData(row);
		}
	}

	public IEnumerator LoadSceneBuffData(SceneBuffTable.Row rowData)
	{
		string name = rowData.Name;
		string assetBundle = "effect/halfloadeffect";
		AssetInfo particle = new AssetInfo(assetBundle, $"Assets/Res/Assets/effect/halfloadeffect/{name}/particleEffectConfig.xml", typeof(ParticleXmlAsset), optional: true);
		AssetInfo effect = new AssetInfo(assetBundle, $"Assets/Res/Assets/effect/halfloadeffect/{name}/effectConfig.xml", typeof(EffectXmlAsset), optional: true);
		SingletonInstance<AssetPool>.Instance.LoadAndAdd(particle, BaseAsyncManager.Instance);
		SingletonInstance<AssetPool>.Instance.LoadAndAdd(effect, BaseAsyncManager.Instance);
		yield return SingletonInstance<AssetPool>.Instance.WaitForAsset(particle);
		yield return SingletonInstance<AssetPool>.Instance.WaitForAsset(effect);
		ParticleXmlAsset particleXmlAsset = SingletonInstance<AssetPool>.Instance.GetOrNull(particle) as ParticleXmlAsset;
		EffectXmlAsset effectXmlAsset = SingletonInstance<AssetPool>.Instance.GetOrNull(effect) as EffectXmlAsset;
		if (particleXmlAsset != null || effectXmlAsset != null)
		{
			ParticleManager.Instance().ParsePreloadingEffect(assetBundle, particleXmlAsset, effectXmlAsset, $"Assets/Res/Assets/effect/halfloadeffect/{name}", preLoadRes: false);
		}
	}
}
