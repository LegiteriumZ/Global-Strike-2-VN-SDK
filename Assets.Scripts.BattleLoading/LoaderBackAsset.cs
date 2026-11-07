using System.Collections.Generic;
using System.Xml;
using Assets.Sources.Constant;

namespace Assets.Scripts.BattleLoading;

public static class LoaderBackAsset
{
	private class LoaderAssetConfig
	{
		public string Texture;

		public string Platform;

		public int Channel;

		public int RaceType;

		public int BigRaceType;

		public int Team;

		public bool IsNewPlayer;

		public int HallModeRuleId;
	}

	private static List<LoaderAssetConfig> GetLoaderAssetConfig(string xml)
	{
		List<LoaderAssetConfig> list = new List<LoaderAssetConfig>();
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xml);
		foreach (XmlElement item in xmlDocument.SelectSingleNode("root").SelectNodes("config"))
		{
			LoaderAssetConfig loaderAssetConfig = new LoaderAssetConfig();
			loaderAssetConfig.Texture = item.GetAttribute("texture");
			loaderAssetConfig.Platform = item.GetAttribute("platform");
			loaderAssetConfig.Team = ((!string.IsNullOrEmpty(item.GetAttribute("team"))) ? int.Parse(item.GetAttribute("team")) : 0);
			loaderAssetConfig.RaceType = ((!string.IsNullOrEmpty(item.GetAttribute("raceType"))) ? int.Parse(item.GetAttribute("raceType")) : 0);
			loaderAssetConfig.BigRaceType = ((!string.IsNullOrEmpty(item.GetAttribute("bigRaceType"))) ? int.Parse(item.GetAttribute("bigRaceType")) : 0);
			loaderAssetConfig.Channel = ((!string.IsNullOrEmpty(item.GetAttribute("channel"))) ? int.Parse(item.GetAttribute("channel")) : 0);
			loaderAssetConfig.IsNewPlayer = item.GetAttribute("isNewPlayer") == "1";
			loaderAssetConfig.HallModeRuleId = ((!string.IsNullOrEmpty(item.GetAttribute("hallModeRuleId"))) ? int.Parse(item.GetAttribute("hallModeRuleId")) : 0);
			list.Add(loaderAssetConfig);
		}
		return list;
	}

	private static void SpecailRpg(int raceType, ref int hallRuleId)
	{
		if (raceType == 18015)
		{
			hallRuleId = 0;
		}
	}

	public static string GetLoaderBackUrl(string xml, int raceType, int channel, string platform, int team, bool isNewPlayer, int hallModeRuleId)
	{
		List<LoaderAssetConfig> loaderAssetConfig = GetLoaderAssetConfig(xml);
		SpecailRpg(raceType, ref hallModeRuleId);
		LoaderAssetConfig newPlayerLoaderAssetConfig = GetNewPlayerLoaderAssetConfig(loaderAssetConfig, isNewPlayer);
		if (newPlayerLoaderAssetConfig != null)
		{
			return newPlayerLoaderAssetConfig.Texture;
		}
		newPlayerLoaderAssetConfig = GetHallModeRuleIdLoaderAssetConfig(loaderAssetConfig, hallModeRuleId);
		if (newPlayerLoaderAssetConfig != null)
		{
			return newPlayerLoaderAssetConfig.Texture;
		}
		newPlayerLoaderAssetConfig = GetChannelLoaderAssetConfig(loaderAssetConfig, channel);
		if (newPlayerLoaderAssetConfig != null)
		{
			return newPlayerLoaderAssetConfig.Texture;
		}
		newPlayerLoaderAssetConfig = GetRaceTypeLoaderAssetConfig(loaderAssetConfig, raceType);
		if (newPlayerLoaderAssetConfig != null)
		{
			return newPlayerLoaderAssetConfig.Texture;
		}
		newPlayerLoaderAssetConfig = GetBigRaceTypeLoaderAssetConfig(loaderAssetConfig, raceType);
		if (newPlayerLoaderAssetConfig != null)
		{
			return newPlayerLoaderAssetConfig.Texture;
		}
		newPlayerLoaderAssetConfig = GetPlatformLoaderAssetConfig(loaderAssetConfig, platform);
		if (newPlayerLoaderAssetConfig != null)
		{
			return newPlayerLoaderAssetConfig.Texture;
		}
		return GetTeamLoaderAssetConfig(loaderAssetConfig, team)?.Texture;
	}

	private static LoaderAssetConfig GetHallModeRuleIdLoaderAssetConfig(List<LoaderAssetConfig> list, int hallModeRuleId)
	{
		if (hallModeRuleId > 0)
		{
			foreach (LoaderAssetConfig item in list)
			{
				if (item.HallModeRuleId == hallModeRuleId)
				{
					return item;
				}
			}
		}
		return null;
	}

	private static LoaderAssetConfig GetNewPlayerLoaderAssetConfig(List<LoaderAssetConfig> list, bool isNewPlayer)
	{
		if (!isNewPlayer)
		{
			return null;
		}
		foreach (LoaderAssetConfig item in list)
		{
			if (item.IsNewPlayer)
			{
				return item;
			}
		}
		return null;
	}

	private static LoaderAssetConfig GetTeamLoaderAssetConfig(List<LoaderAssetConfig> list, int team)
	{
		if (team > 0)
		{
			foreach (LoaderAssetConfig item in list)
			{
				if (team == item.Team)
				{
					return item;
				}
			}
		}
		return null;
	}

	private static LoaderAssetConfig GetPlatformLoaderAssetConfig(List<LoaderAssetConfig> list, string platform)
	{
		if (!string.IsNullOrEmpty(platform))
		{
			foreach (LoaderAssetConfig item in list)
			{
				if (platform == item.Platform)
				{
					return item;
				}
			}
		}
		return null;
	}

	private static LoaderAssetConfig GetBigRaceTypeLoaderAssetConfig(List<LoaderAssetConfig> list, int raceType)
	{
		foreach (LoaderAssetConfig item in list)
		{
			if (item.BigRaceType == 9014 && RuleUtilty.IsBlade(raceType))
			{
				return item;
			}
			if (item.BigRaceType == 9011 && RuleUtilty.IsBigHeadModel(raceType))
			{
				return item;
			}
			if (item.BigRaceType == 9010 && RuleUtilty.IsBioMode(raceType))
			{
				return item;
			}
			if (item.BigRaceType == 9012 && RuleUtilty.IsExplode(raceType))
			{
				return item;
			}
			if (item.BigRaceType == 9013 && RuleUtilty.IsGroupModel(raceType))
			{
				return item;
			}
			if (item.BigRaceType == 9017 && RuleUtilty.IsBotMode(raceType))
			{
				return item;
			}
			if (item.BigRaceType == 4 && raceType == 4)
			{
				return item;
			}
			if (item.BigRaceType == 5 && raceType == 5)
			{
				return item;
			}
			if (item.BigRaceType == 9050 && raceType == 5)
			{
				return item;
			}
			if (item.BigRaceType == 10000 && RuleUtilty.IsGeneralPve(raceType))
			{
				return item;
			}
		}
		return null;
	}

	private static LoaderAssetConfig GetRaceTypeLoaderAssetConfig(List<LoaderAssetConfig> list, int raceType)
	{
		if (raceType > 0)
		{
			foreach (LoaderAssetConfig item in list)
			{
				if (raceType == item.RaceType)
				{
					return item;
				}
			}
		}
		return null;
	}

	private static LoaderAssetConfig GetChannelLoaderAssetConfig(List<LoaderAssetConfig> list, int channel)
	{
		if (channel > 0)
		{
			foreach (LoaderAssetConfig item in list)
			{
				if (channel == item.Channel)
				{
					return item;
				}
			}
		}
		return null;
	}
}
