using System.Collections.Generic;
using SSJJBase.Cache;
using SSJJBase.Logger;

namespace Assets.Sources.Info.Career;

public class PlayerSkinInfoFactory
{
	private class PlayerSkinInfoCacheFactory : ICacheObjectFactory<string, PlayerSkinInfo>
	{
		public PlayerSkinInfo CreateObject(string name)
		{
			this.LogErrorFormat("PlayerSkinInfo not exist in csv file {0}", name);
			return null;
		}
	}

	public static PlayerSkinInfoFactory Instance = new PlayerSkinInfoFactory();

	private readonly ObjectCache<string, PlayerSkinInfo> _playerInfoCache = new ObjectCache<string, PlayerSkinInfo>(new PlayerSkinInfoCacheFactory());

	public PlayerSkinInfo GetSkinInfo(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return null;
		}
		return _playerInfoCache.GetOrNull(name);
	}

	public Dictionary<string, PlayerSkinInfo>.ValueCollection GetAllPlayerInfos()
	{
		return _playerInfoCache.Values();
	}

	public void Add(PlayerSkinInfo skinInfo)
	{
		_playerInfoCache.Add(skinInfo.Name, skinInfo);
	}
}
