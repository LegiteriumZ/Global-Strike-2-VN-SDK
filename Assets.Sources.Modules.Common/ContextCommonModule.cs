using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Common;

public class ContextCommonModule : GameModule
{
	private readonly IContextResourceInfo _resourceInfo;

	private readonly IContextDestroyInfo _destroyInfo;

	private readonly IContextLifeTimeInfo _lifeTimeInfo;

	protected override void OnAddEntityCreateSystems(Contexts contexts, List<IEntityCreateSystem> systems)
	{
		base.OnAddEntityCreateSystems(contexts, systems);
	}

	protected override void OnAddEntityPreDestroySystems(Contexts contexts, List<IEntityPreDestroySystem> systems)
	{
		if (_lifeTimeInfo != null)
		{
			systems.Add(new CommonEntityLifeTimeSystem(_lifeTimeInfo));
		}
	}

	protected override void OnAddEntityDestroySystems(Contexts contexts, List<IEntityDestroySystem> systems)
	{
		if (_resourceInfo != null)
		{
			systems.Add(new CommonResourceDestroySystem(contexts, _resourceInfo, _resourceInfo));
		}
	}

	protected override void OnAddEntityPostDestroySystems(Contexts contexts, List<IEntityPostDestroySystem> systems)
	{
		if (_destroyInfo != null)
		{
			systems.Add(new CommonEntityDestroySystem(_destroyInfo));
		}
	}

	protected override void OnAddCommonResourceLoadSystems(Contexts contexts, List<IResourceLoadSystem> systems)
	{
		systems.Add(new CommonResourceLoadSystem(contexts, _resourceInfo));
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
	}

	public ContextCommonModule(Contexts contexts, IContextResourceInfo resourceInfo, IContextDestroyInfo destroyInfo, IContextLifeTimeInfo lifeTimeInfo)
		: base(contexts)
	{
		_resourceInfo = resourceInfo;
		_destroyInfo = destroyInfo;
		_lifeTimeInfo = lifeTimeInfo;
	}
}
