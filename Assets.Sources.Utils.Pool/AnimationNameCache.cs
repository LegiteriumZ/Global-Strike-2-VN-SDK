using System.Collections.Generic;
using Assets.Sources.Utils.Ui;

namespace Assets.Sources.Utils.Pool;

public class AnimationNameCache
{
	private static Dictionary<AbstractParams, string> _cache = new Dictionary<AbstractParams, string>();

	public static bool TryGet(AbstractParams key, out string cachedata)
	{
		return _cache.TryGetValue(key, out cachedata);
	}

	public static bool Contains(AbstractParams key)
	{
		return _cache.ContainsKey(key);
	}

	public static void Add(AbstractParams key, string data)
	{
		_cache[key] = data;
	}

	public static void Clear()
	{
		_cache.Clear();
	}
}
