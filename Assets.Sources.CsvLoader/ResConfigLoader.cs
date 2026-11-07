using System.Collections;
using Assets.Generated.Table;
using Assets.Sources.Info.Res;
using SSJJAsset.AssetManager;
using SSJJBase.Manager;
using UnityEngine;

namespace Assets.Sources.CsvLoader;

internal class ResConfigLoader
{
	private static ResConfigLoader _instance;

	public static ResConfigLoader Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new ResConfigLoader();
			}
			return _instance;
		}
	}

	public IEnumerator Load()
	{
		AssetAsyncLoader<TextAsset> loader = new AssetAsyncLoader<TextAsset>();
		yield return LoadWeaponHoleAsync(loader);
		yield return LoadWeaponRailAsync(loader);
		yield return LoadExplisonAsync(loader);
		yield return LoadExplisonEffectAsync(loader);
		yield return LoadMoveEneityAsync(loader);
		yield return LoadMoveEneityTailAsync(loader);
	}

	private static IEnumerator LoadExplisonEffectAsync(AssetAsyncLoader<TextAsset> loader)
	{
		yield return loader.LoadAsync("tables", "Explosion");
		string text = loader.Result.text;
		ExplosionTable explosionTable = new ExplosionTable();
		explosionTable.Load(text);
		foreach (ExplosionTable.Row row in explosionTable.GetRowList())
		{
			BattleSingletonInstance<ResConfigFactory>.Instance.Add(new ExplosionConfig(row));
		}
	}

	private static IEnumerator LoadExplisonAsync(AssetAsyncLoader<TextAsset> loader)
	{
		yield return loader.LoadAsync("tables", "ExplosionEffect");
		string text = loader.Result.text;
		ExplosionEffectTable explosionEffectTable = new ExplosionEffectTable();
		explosionEffectTable.Load(text);
		foreach (ExplosionEffectTable.Row row in explosionEffectTable.GetRowList())
		{
			BattleSingletonInstance<ResConfigFactory>.Instance.Add(new ExplosionEffectConfig(row));
		}
	}

	private static IEnumerator LoadWeaponRailAsync(AssetAsyncLoader<TextAsset> loader)
	{
		yield return loader.LoadAsync("tables", "WeaponRail");
		string text = loader.Result.text;
		WeaponRailTable weaponRailTable = new WeaponRailTable();
		weaponRailTable.Load(text);
		foreach (WeaponRailTable.Row row in weaponRailTable.GetRowList())
		{
			BattleSingletonInstance<ResConfigFactory>.Instance.Add(new RailResConfig(row));
		}
	}

	private static IEnumerator LoadMoveEneityAsync(AssetAsyncLoader<TextAsset> loader)
	{
		yield return loader.LoadAsync("tables", "MoveEntity");
		string text = loader.Result.text;
		MoveEntityTable moveEntityTable = new MoveEntityTable();
		moveEntityTable.Load(text);
		foreach (MoveEntityTable.Row row in moveEntityTable.GetRowList())
		{
			BattleSingletonInstance<ResConfigFactory>.Instance.Add(new MoveEntityConfig(row));
		}
	}

	private static IEnumerator LoadMoveEneityTailAsync(AssetAsyncLoader<TextAsset> loader)
	{
		yield return loader.LoadAsync("tables", "MoveEntityTail");
		string text = loader.Result.text;
		MoveEntityTailTable moveEntityTailTable = new MoveEntityTailTable();
		moveEntityTailTable.Load(text);
		foreach (MoveEntityTailTable.Row row in moveEntityTailTable.GetRowList())
		{
			BattleSingletonInstance<ResConfigFactory>.Instance.Add(new MoveEntityTailConfig(row));
		}
	}

	private static IEnumerator LoadWeaponHoleAsync(AssetAsyncLoader<TextAsset> loader)
	{
		yield return loader.LoadAsync("tables", "WeaponHole");
		string text = loader.Result.text;
		WeaponHoleTable weaponHoleTable = new WeaponHoleTable();
		weaponHoleTable.Load(text);
		foreach (WeaponHoleTable.Row row in weaponHoleTable.GetRowList())
		{
			BattleSingletonInstance<ResConfigFactory>.Instance.Add(new HoleResConfig(row));
		}
	}
}
