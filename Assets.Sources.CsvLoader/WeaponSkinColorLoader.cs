using System.Collections;
using System.Collections.Generic;
using NetData;
using SSJJAsset.AssetManager;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.CsvLoader;

public class WeaponSkinColorLoader : SingletonInstance<WeaponSkinColorLoader>
{
	public List<Texture2D> Skins = new List<Texture2D>();

	public WeaponColorData DefaultWeaponColorData;

	public void Init()
	{
		DefaultWeaponColorData = new WeaponColorData
		{
			R = 1f,
			G = 1f,
			B = 1f,
			A = 1f
		};
	}

	public IEnumerator Load()
	{
		Init();
		AssetAsyncLoader<Texture2D> xmlLoader = new AssetAsyncLoader<Texture2D>();
		for (int i = 1; i <= 3; i++)
		{
			yield return xmlLoader.LoadAsync("weapon/colorskin", $"{i}.png");
			Skins.Add(xmlLoader.Result);
		}
	}
}
