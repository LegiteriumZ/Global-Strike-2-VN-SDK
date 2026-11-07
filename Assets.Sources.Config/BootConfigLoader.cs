using System;
using System.Xml.Linq;
using Assets.Scripts.PlatformRunTime;
using NetData;
using SSJJBase.Logger;

namespace Assets.Sources.Config;

public static class BootConfigLoader
{
	private static LoggerAdapter _logger = new LoggerAdapter(typeof(BootConfigLoader));

	public static GameBootConfig LoadBootConfig()
	{
		try
		{
			XElement xElement = LocalConfigManager.Instance.LoadXmlConfig("boot_config.xml");
			return new GameBootConfig
			{
				ResourceBase = (string)xElement.Element("ResourceBase"),
				BattleServerIp = (string)xElement.Element("BattleServer").Element("IP"),
				BattleServerTcpPort = int.Parse((string)xElement.Element("BattleServer").Element("TcpPort")),
				BattleServerUdpPort = int.Parse((string)xElement.Element("BattleServer").Element("UdpPort")),
				CharId = 0L,
				ClientDebug = false,
				ExternalUrl = "",
				GameStartCount = 1,
				GenerateId = 0,
				IsDirectProxy = false,
				IsGlobalServer = false,
				IsPluginReportEnable = false,
				IsMicroClient = true,
				LoginId = 1,
				Platform = "",
				Sign = "",
				SceneTcpProxy = "",
				ServerId = 0,
				StatUrl = "",
				SignFileName = "",
				Timestamp = "",
				UserId = 0L,
				SelfKillNormal = "defaultkill",
				SelfKillKnife = "defaultkill",
				SelfKillHeadShot = "headshot",
				SelfKillSpecial = "defaultkill"
			};
		}
		catch (Exception ex)
		{
			_logger.Error("error while parsing boot_config.xml: {0}" + ex);
		}
		return null;
	}

	public static GameBootConfig LoadBootConfig(BootConfigData bootConfig)
	{
		GameBootConfig gameBootConfig = new GameBootConfig
		{
			RoomId = bootConfig.RoomId,
			BattleServerIp = bootConfig.BattleServerIp,
			BattleServerTcpPort = bootConfig.BattleServerTcpPort,
			BattleServerUdpPort = bootConfig.BattleServerUdpPort,
			CharId = bootConfig.CharId,
			ClientDebug = bootConfig.ClientDebug,
			ExternalUrl = bootConfig.ExternalUrl,
			GameStartCount = bootConfig.GameStartCount,
			GenerateId = bootConfig.GenerateId,
			IsDirectProxy = bootConfig.IsDirectProxy,
			IsGlobalServer = bootConfig.IsGlobalServer,
			IsPluginReportEnable = bootConfig.IsPluginReportEnable,
			LoginId = bootConfig.LoginId,
			Platform = bootConfig.Platform,
			ResourceBase = bootConfig.ResourceBase,
			Sign = bootConfig.Sign,
			SceneTcpProxy = bootConfig.SceneTcpProxy,
			ServerId = bootConfig.ServerId,
			StatUrl = bootConfig.StatUrl,
			SignFileName = bootConfig.SignFileName,
			Timestamp = bootConfig.Timestamp,
			UserId = bootConfig.UserId,
			IsNewPlayer = (!string.IsNullOrEmpty(bootConfig.IsNewPlayer) && bootConfig.IsNewPlayer.Equals("true", StringComparison.OrdinalIgnoreCase)),
			IsSpeechControlClose = bootConfig.SpeechControlClose,
			HallModeRuleId = bootConfig.HallModeRuleId,
			IsSplashEffectOpen = bootConfig.EffectIsOpen,
			PveSplashEffectType = bootConfig.PveEffectType,
			PvpSplashEffectType = bootConfig.PvpEffectType,
			PveSplashEffectColor = bootConfig.PveEffectColor,
			PvpSplashEffectColor = bootConfig.PvpEffectColor,
			SelfKillNormal = bootConfig.SelfKillNormal,
			SelfKillHeadShot = bootConfig.SelfKillHeadshot,
			SelfKillKnife = bootConfig.SelfKillKnife,
			SelfKillSpecial = bootConfig.SelfKillSpecial,
			GameStartJsonAttribute = bootConfig.GameStartJsonAttribute
		};
		if (PlatformConstant.IsTx(gameBootConfig.Platform))
		{
			gameBootConfig.NpOpen = true;
		}
		return gameBootConfig;
	}
}
