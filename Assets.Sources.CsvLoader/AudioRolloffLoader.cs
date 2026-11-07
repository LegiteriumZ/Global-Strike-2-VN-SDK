using System.Collections;
using Assets.Generated.Table;
using SSJJAsset.AssetManager;
using UnityEngine;

namespace Assets.Sources.CsvLoader;

public class AudioRolloffLoader
{
	private static AudioRolloffLoader _instance;

	public static AudioRolloffLoader Instance => _instance ?? (_instance = new AudioRolloffLoader());

	public AudioRolloffTable Table { get; private set; }

	public AudioRolloffLoader()
	{
		Table = new AudioRolloffTable();
	}

	public IEnumerator Load()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return loader.LoadAsync("tables", "AudioRolloff");
		TextAsset result = loader.Result;
		Table.Load(result.text);
	}
}
