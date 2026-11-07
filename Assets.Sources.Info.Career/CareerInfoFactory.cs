using Assets.Sources.Components.Interface.Info.Career;
using SSJJBase.Cache;

namespace Assets.Sources.Info.Career;

public class CareerInfoFactory
{
	private class CareerInfoCacheCacheFactory : ICacheObjectFactory<string, ICareerInfo>
	{
		public ICareerInfo CreateObject(string career)
		{
			return new DefaultCareerInfo(career);
		}
	}

	public static CareerInfoFactory Instance = new CareerInfoFactory();

	private readonly ObjectCache<string, ICareerInfo> _cache = new ObjectCache<string, ICareerInfo>(new CareerInfoCacheCacheFactory());

	public ICareerInfo GetCareerInfo(string career)
	{
		return _cache.GetOrCreate(career);
	}
}
