using System.Collections.Generic;
using Entitas;

namespace Assets.Sources.Modules.Common;

public interface IContextLifeTimeInfo : IContextDestroyInfo, IContextCommonInfo
{
	int LifeTimeComponentId { get; }

	List<IEntity> LifeTimeEntities { get; }
}
