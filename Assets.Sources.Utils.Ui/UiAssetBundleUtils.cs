using System;
using System.Collections.Generic;
using Assets.Sources.Utils.Pool;
using SSJJAsset.Asset;
using SSJJBase.String;

namespace Assets.Sources.Utils.Ui;

public static class UiAssetBundleUtils
{
	private static Dictionary<int, string> _modeBundle = new Dictionary<int, string> { { 3, "team" } };

	public static string ModeConfigBundleName => "modeconfig";

	public static string UiConfigBundleName => "uiconfig";

	public static string UiBundleName => "ui/common";

	public static string GetUiPrefabBundleName()
	{
		return "uiprefabs/";
	}

	public static string GetUiBundleName()
	{
		return "ui/";
	}

	public static string GetWeaponBundleName(string weaponName)
	{
		return "weapon/" + weaponName;
	}

	public static string GetCommonFreeBundleName()
	{
		return "ui/commonfree";
	}

	public static string GetUiFullPath()
	{
		return "Assets/Res/Assets/ui/GameGUIRes/";
	}

	public static string GetWeaponFullPath()
	{
		return "Assets/Res/Assets/weapon/";
	}

	public static string GetWeaponTexturePath(string weaponName, string pngName)
	{
		SimpleParams simpleParams = SimpleParams.Create(weaponName, pngName);
		if (!AnimationNameCache.TryGet(simpleParams, out var cachedata))
		{
			cachedata = $"{GetWeaponFullPath()}{weaponName}/ui/{pngName}.png";
			AnimationNameCache.Add(simpleParams, cachedata);
		}
		else
		{
			simpleParams.Release();
		}
		return cachedata;
	}

	public static string GetWeaponEffectXmlPath(string weaponName)
	{
		SimpleParams simpleParams = SimpleParams.Create(weaponName);
		if (!AnimationNameCache.TryGet(simpleParams, out var cachedata))
		{
			cachedata = GetWeaponFullPath() + weaponName + "/effect/weaponeffectconfig.xml";
			AnimationNameCache.Add(simpleParams, cachedata);
		}
		else
		{
			simpleParams.Release();
		}
		return cachedata;
	}

	public static string GetHalfLoadFullPath()
	{
		return "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/";
	}

	public static string GetCommonFreeFullPath()
	{
		return "Assets/Res/Assets/ui/GameGUIRes/commonfree/";
	}

	public static string GetRadarMapFullPath(string mapName)
	{
		return "map.png";
	}

	public static string GetMiniMapBackFullPath(string mapName)
	{
		return "smallmapback";
	}

	public static string GetCommonMapResFullPath(string resName)
	{
		SimpleParams simpleParams = SimpleParams.Create(resName);
		if (!AnimationNameCache.TryGet(simpleParams, out var cachedata))
		{
			cachedata = $"Assets/Res/Assets/ui/GameGUIRes/commonfree/map/{resName}.png";
			AnimationNameCache.Add(simpleParams, cachedata);
		}
		else
		{
			simpleParams.Release();
		}
		return cachedata;
	}

	public static string GetModeResourceConfigPath(string name)
	{
		SimpleParams simpleParams = SimpleParams.Create(name);
		if (!AnimationNameCache.TryGet(simpleParams, out var cachedata))
		{
			cachedata = $"Assets/Res/Assets/moderesourcesconfig/{name}.xml";
			AnimationNameCache.Add(simpleParams, cachedata);
		}
		else
		{
			simpleParams.Release();
		}
		return cachedata;
	}

	public static string GetTablesConfigPath(string name)
	{
		SimpleParams simpleParams = SimpleParams.Create(name);
		if (!AnimationNameCache.TryGet(simpleParams, out var cachedata))
		{
			cachedata = $"Assets/Res/Assets/tables/{name}.xml";
			AnimationNameCache.Add(simpleParams, cachedata);
		}
		else
		{
			simpleParams.Release();
		}
		return cachedata;
	}

	public static AssetInfo GetAssetInfo(string bundleName, string configPath)
	{
		AssetInfo result = default(AssetInfo);
		result.BundleName = new IgnoreCaseString(bundleName);
		result.AssetName = new IgnoreCaseString(configPath);
		return result;
	}

	public static AssetInfo GetTablesConfigAssetInfo(string configName)
	{
		AssetInfo result = default(AssetInfo);
		result.BundleName = new IgnoreCaseString("tables");
		result.AssetName = new IgnoreCaseString(GetTablesConfigPath(configName));
		return result;
	}

	public static AssetInfo GetModeResourceConfigAssetInfo(string configName)
	{
		AssetInfo result = default(AssetInfo);
		result.BundleName = new IgnoreCaseString(ModeConfigBundleName);
		result.AssetName = new IgnoreCaseString(GetModeResourceConfigPath(configName));
		return result;
	}

	public static AssetInfo GetModeTileAssetInfo(string name)
	{
		AssetInfo result = default(AssetInfo);
		result.AssetName = new IgnoreCaseString(name);
		return result;
	}

	public static AssetInfo GetModeNameAssetInfo(string name)
	{
		AssetInfo result = default(AssetInfo);
		result.AssetName = new IgnoreCaseString(name);
		return result;
	}

	public static string GetModeBundleName(int mode)
	{
		if (_modeBundle.ContainsKey(mode))
		{
			return GetUiBundleName() + _modeBundle[mode];
		}
		throw new NotSupportedException(mode + " Mode Not Supported");
	}

	public static string GetModePrefabBundleName(int mode)
	{
		if (_modeBundle.ContainsKey(mode))
		{
			return GetUiPrefabBundleName() + _modeBundle[mode];
		}
		throw new NotSupportedException(mode + " Mode Not Supported");
	}
}
