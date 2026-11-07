using System;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Utils;

public static class TimeUtility
{
	public static void SetServerTime(TimeComponent timeComp, int serverTime)
	{
		timeComp.ServerTimeDelta = serverTime - timeComp.ClientRealTime;
	}

	public static long UnixTimeNow()
	{
		return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalMilliseconds;
	}

	public static int GetSectionTimeMinutes(SectionTimeComponent sectionTime)
	{
		long sectionStartTimeClient = sectionTime.SectionStartTimeClient;
		int sectionTime2 = sectionTime.SectionTime;
		if (sectionStartTimeClient <= 0 || sectionTime2 <= 0)
		{
			return 0;
		}
		return sectionTime2 / 1000 / 60;
	}

	public static int GetSectionTimeSeconds(SectionTimeComponent sectionTime)
	{
		long sectionStartTimeClient = sectionTime.SectionStartTimeClient;
		int sectionTime2 = sectionTime.SectionTime;
		if (sectionStartTimeClient <= 0 || sectionTime2 <= 0)
		{
			return 0;
		}
		return sectionTime2 / 1000 % 60;
	}
}
