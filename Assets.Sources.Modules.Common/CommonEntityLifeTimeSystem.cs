using System;
using Assets.Sources.Components.Common;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Common;

public class CommonEntityLifeTimeSystem : IEntityPreDestroySystem
{
	private readonly IContextLifeTimeInfo _lifeTimeInfo;

	public CommonEntityLifeTimeSystem(IContextLifeTimeInfo lifeTimeInfo)
	{
		_lifeTimeInfo = lifeTimeInfo;
	}

	public void OnEntityPreDestroy()
	{
		foreach (IEntity lifeTimeEntity in _lifeTimeInfo.LifeTimeEntities)
		{
			LifeTimeComponent lifeTimeComponent = (LifeTimeComponent)lifeTimeEntity.GetComponent(_lifeTimeInfo.LifeTimeComponentId);
			if ((DateTime.Now - lifeTimeComponent.CreateTime).TotalMilliseconds > (double)lifeTimeComponent.LifeTime && !lifeTimeEntity.HasComponent(_lifeTimeInfo.DestroyComponentId))
			{
				IComponent component = lifeTimeEntity.CreateComponent(_lifeTimeInfo.DestroyComponentId, _lifeTimeInfo.ComponentTypes[_lifeTimeInfo.DestroyComponentId]);
				lifeTimeEntity.AddComponent(_lifeTimeInfo.DestroyComponentId, component);
			}
		}
	}
}
