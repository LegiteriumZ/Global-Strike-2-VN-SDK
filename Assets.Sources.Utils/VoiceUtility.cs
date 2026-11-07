using System;
using Assets.Sources.Constant;
using Assets.Sources.Utils.Sound;
using UnityEngine;
using agora_gaming_rtc;

namespace Assets.Sources.Utils;

public class VoiceUtility
{
	public static void QuitVoice()
	{
		IRtcEngine rtcEngine = IRtcEngine.QueryEngine();
		if (rtcEngine != null)
		{
			rtcEngine.LeaveChannel();
			IRtcEngine.Destroy();
		}
	}

	public static bool IsOperatingSystemCanRunVoice()
	{
		if (SystemInfo.operatingSystem.IndexOf("xp", StringComparison.OrdinalIgnoreCase) > -1)
		{
			return false;
		}
		return true;
	}

	public static bool CheckVoiceIsForbiden(int raceType)
	{
		return true;
	}

	public static bool CheckVoiceIsForbidenForCreateMode(int raceType)
	{
		if (!RuleUtilty.IsBigHeadModel(raceType) && !RuleUtilty.IsExplode(raceType) && !RuleUtilty.IsGroupModel(raceType) && !RuleUtilty.IsGeneralPve(raceType))
		{
			return true;
		}
		return false;
	}

	public static void AdjustVoiceVolume()
	{
		IRtcEngine rtcEngine = IRtcEngine.QueryEngine();
		if (rtcEngine != null)
		{
			int volume = (int)(40f + 100f * GameSoundManager.Config.VoiceListenVolume);
			int volume2 = (int)(40f + 100f * GameSoundManager.Config.VoiceSpeakVolume);
			rtcEngine.AdjustPlaybackSignalVolume(volume);
			rtcEngine.AdjustRecordingSignalVolume(volume2);
		}
	}
}
