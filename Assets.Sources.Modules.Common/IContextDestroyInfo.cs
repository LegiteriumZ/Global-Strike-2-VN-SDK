using System.Collections.Generic;
using Entitas;

namespace Assets.Sources.Modules.Common;

public interface IContextDestroyInfo : IContextCommonInfo
{
	int DestroyComponentId { get; }

	List<IEntity> DestoryEntities { get; }
}
