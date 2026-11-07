using System.Collections.Generic;
using Assets.Res.Assets.Scripts.Sources.Info.GPUAnim;
using SSJJBase.Cache;
using SSJJBase.Logger;
using SSJJBase.Manager;

namespace Assets.Sources.Info.GPUAnim;

public class GpuAnimInfoFactory : BattleSingletonInstance<GpuAnimInfoFactory>
{
	private class GPUAnimInfoCacheFactory : ICacheObjectFactory<string, GPUAnimInfo>
	{
		public GPUAnimInfo CreateObject(string name)
		{
			this.LogErrorFormat("WeaponInfo not exist in csv file {0}", name);
			return null;
		}
	}

	private readonly ObjectCache<string, GPUAnimInfo> _gpuAnimInfoCache = new ObjectCache<string, GPUAnimInfo>(new GPUAnimInfoCacheFactory());

	public GPUAnimInfo GetSkinInfo(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return null;
		}
		return _gpuAnimInfoCache.GetOrNull(name);
	}

	public void Add(GPUAnimInfo spuAnimInfo)
	{
		_gpuAnimInfoCache.Add(spuAnimInfo.Name, spuAnimInfo);
	}

	public Dictionary<string, GPUAnimInfo>.ValueCollection GetAllWeaponSkinInfos()
	{
		return _gpuAnimInfoCache.Values();
	}

	public override void Clear()
	{
		_gpuAnimInfoCache.Clear();
	}
}
