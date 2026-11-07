using SSJJBase.Cache;
using SSJJBase.Logger;
using weapon.predicateSystem;

namespace Assets.Sources.Info.Weapon;

public class PredicationConfigFactory
{
	private class PredicationConfigCacheFactory : ICacheObjectFactory<string, PredicationConfig>
	{
		public PredicationConfig CreateObject(string name)
		{
			this.LogErrorFormat("WeaponInfo not exist in csv file {0}", name);
			return new PredicationConfig();
		}
	}

	public static PredicationConfigFactory Instance = new PredicationConfigFactory();

	private readonly ObjectCache<string, PredicationConfig> _predicationConfigCache = new ObjectCache<string, PredicationConfig>(new PredicationConfigCacheFactory());

	public PredicationConfig GetPredicationConfig(string name)
	{
		return _predicationConfigCache.GetOrNull(name);
	}

	public void Add(PredicationConfig info, string name)
	{
		_predicationConfigCache.Add(name, info);
	}
}
