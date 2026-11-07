using System.Collections.Generic;
using Entitas;

namespace Assets.Sources.Modules.Common;

public interface IContextResourceInfo : IContextDestroyInfo, IContextCommonInfo
{
	int[] LoadComponentIds { get; }

	int[] UnityComponentIds { get; }

	List<IEntity> LoadResourceEntities { get; }
}
