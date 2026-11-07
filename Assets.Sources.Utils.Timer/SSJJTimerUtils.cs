using System.Collections.Generic;
using Assets.Sources.Components.Interface;

namespace Assets.Sources.Utils.Timer;

public static class SSJJTimerUtils
{
	public static ISSJJTimer AddTimer(Dictionary<string, ISSJJTimer> timers, string key, ISSJJTimer timer)
	{
		if (timers == null)
		{
			return null;
		}
		if (timers.ContainsKey(key))
		{
			timers[key] = timer;
		}
		else
		{
			timers.Add(key, timer);
		}
		return timer;
	}

	public static bool RemoveTimer(Dictionary<string, ISSJJTimer> timers, string key)
	{
		if (timers.ContainsKey(key))
		{
			timers.Remove(key);
			return true;
		}
		return false;
	}
}
