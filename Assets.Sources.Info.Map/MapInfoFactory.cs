using Assets.Sources.Components.Interface.Info.Map;
using SSJJBase.Cache;
using SSJJBase.Manager;

namespace Assets.Sources.Info.Map;

public class MapInfoFactory : BattleSingletonInstance<MapInfoFactory>
{
	private class MapInfoCacheCacheFactory : ICacheObjectFactory<int, IMapInfo>
	{
		public IMapInfo CreateObject(int name)
		{
			return new DefaultMapInfo(name);
		}
	}

	private readonly ObjectCache<int, IMapInfo> _mapInfoCache = new ObjectCache<int, IMapInfo>(new MapInfoCacheCacheFactory());

	public IMapInfo GetMapInfo(int id)
	{
		return _mapInfoCache.GetOrCreate(id);
	}

	public void Add(IMapInfo mapInfo)
	{
		_mapInfoCache.Add(mapInfo.Id, mapInfo);
	}

	public override void Clear()
	{
		_mapInfoCache.Clear();
	}
}
